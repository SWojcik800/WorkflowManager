using Dapper;
using Microsoft.EntityFrameworkCore;
using StorageManager.App.Commons.IoC;
using StorageManager.App.Database;
using StorageManager.App.Models;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkflowManager.App.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace WorkflowManager.App.Features.Workflows
{
    internal sealed class WorkflowService(AppDbContext context) : IWorkflowService
    {
        public void DeleteChildren(List<int> deletedFieldsIds, List<int> deletedStagesIds)
        {
            var fields = context.WorkflowFields.Where(x => deletedFieldsIds.Contains(x.Id)).ToList();
            context.WorkflowFields.RemoveRange(fields);

            var stages = context.WorkflowStages.Where(x => deletedStagesIds.Contains(x.Id)).ToList();
            context.WorkflowStages.RemoveRange(stages);

            context.SaveChanges();
        }
        public void Upsert(Workflow workflow, List<int> deletedFieldIds, List<int> deletedStagesIds)
        {
            using (var connection = DbConnectionFactory.Create())
            {
                connection.Open();


                using (var tran = connection.BeginTransaction())
                {
                    var newStageId = new List<int>();
                    var newFieldCodes = new List<string>();
                    var deletedFieldCodes = connection.Query<string>("SELECT [Code] FROM [PMDb].[dbo].[WorkflowFields] WHERE WorkflowId = @WorkflowId AND Id IN @DeletedFieldIds", new
                    {
                        WorkflowId = workflow.Id,
                        DeletedFieldIds = deletedFieldIds
                    }, tran);

                    SaveWorkflowData(workflow, deletedFieldIds, deletedStagesIds, connection, tran, newStageId, newFieldCodes);

                    var querySql = @"select ws.WorkflowId, ws.Id, wf.Code from WorkflowStage ws
                    full join WorkflowFields wf 
                    on ws.WorkflowId = wf.WorkflowId
                    where ws.WorkflowId = @WorkflowId order by ws.StageIndex asc";



                    var items = connection.Query<WorkflowStageFieldCheck>(querySql, new
                    {
                        WorkflowId = workflow.Id,
                    }, transaction: tran);


                    var stageFields = connection.Query<WorkflowStageField>(@"
                    SELECT [Id]
                      ,[WorkflowStageId]
                      ,[FieldCode]
                      ,[IsVisible]
                      ,[IsEditable]
                      ,[IsRequired]
                  FROM [PMDb].[dbo].[WorkflowStageFields]
                  WHERE WorkflowStageId IN @StageIds
                ", new
                    {
                      StageIds = workflow.WorkflowStage.Select(x => x.Id).ToList(),                                                                 
                    }, tran);

                    var rowsToDelete = new List<int>();

                    var rowsToAdd = new List<WorkflowStageField>();
                    foreach (var item in stageFields)
                    {
                        if (deletedStagesIds.Contains(item.WorkflowStageId) || deletedFieldCodes.Contains(item.FieldCode))
                        {
                            connection.Execute("DELETE FROM [dbo].[WorkflowStageFields] WHERE Id = @Id", new
                            {
                                Id = item.Id,
                            }, tran);
                        }
                    }

                    foreach (var item in items)
                    {
                        var sql = @"
                        INSERT INTO [dbo].[WorkflowStageFields]
                                   ([WorkflowStageId]
                                   ,[FieldCode]
                                   ,[IsVisible]
                                   ,[IsEditable]
                                   ,[IsRequired])
                             VALUES
                                   (@WorkflowStageId
                                   ,@FieldCode
                                   ,@IsVisible
                                   ,@IsEditable
                                   ,@IsRequired)
                        ";

                        var rowExists = stageFields.Any(x => x.FieldCode == item.Code && x.WorkflowStageId == item.Id);

                        if (!rowExists)
                        {
                            var row = new WorkflowStageField()
                            {
                                FieldCode = item.Code,
                                WorkflowStageId = item.Id,
                                IsVisible = true,
                                IsEditable = true,
                                IsRequired = false
                            };
                            connection.Execute(sql, row, tran);
                        }

                    }



                    tran.Commit();
                }
            }
            //context.Upsert<Workflow>(workflow);
            //context.SaveChanges();
        }

        public List<WorkflowStageFieldModel> ReadStageFields(int workflowId)
        {
            using (var connection = DbConnectionFactory.Create())
            {
                connection.Open();
                var getStagesSql = "select Id from WorkflowStage where WorkflowId = @WorkflowId";
                var getStagesResult = connection.Query<int>(getStagesSql, new
                {
                    WorkflowId = workflowId
                });

                var sql = @"
                SELECT wf.[Id]
                      ,wf.[WorkflowStageId]
                      ,wf.[FieldCode]
                      ,wf.[IsVisible]
                      ,wf.[IsEditable]
                      ,wf.[IsRequired],
	                  ws.Name as WorkflowStageName
                  FROM [PMDb].[dbo].[WorkflowStageFields] wf
                  left join WorkflowStage ws on ws.Id = wf.[WorkflowStageId]
                  WHERE wf.[WorkflowStageId] IN @StageIds
                  ORDER BY ws.StageIndex ASC
                ";

                var result = connection.Query<WorkflowStageFieldModel>(sql, new
                {
                    StageIds = getStagesResult
                });

                return result.ToList();
            }
        }

        public void UpdateStageFields(List<WorkflowStageFieldModel> stageFields)
        {
            using(var connection = DbConnectionFactory.Create())
            {
                connection.Open();

                using (var tran = connection.BeginTransaction())
                {
                    foreach (var item in stageFields)
                    {
                        var sql = @"UPDATE [dbo].[WorkflowStageFields]
                           SET [IsVisible] = @IsVisible
                              ,[IsEditable] = @IsEditable
                              ,[IsRequired] = @IsRequired
                         WHERE Id = @Id";

                        connection.Execute(sql, item, tran);
                    }

                    tran.Commit();
                }
            }
        }

        private static void SaveWorkflowData(Workflow workflow, List<int> deletedFieldIds, List<int> deletedStagesIds, DbConnection connection, DbTransaction tran, List<int> newStageId, List<string> newFieldCodes)
        {
            foreach (var item in deletedFieldIds)
            {
                if (item != 0)
                {
                    var sql = "DELETE FROM [dbo].[WorkflowFields] WHERE Id = @Id";

                    connection.Execute(sql, new
                    {
                        Id = item
                    }, tran);
                }
            }

            foreach (var item in deletedStagesIds)
            {
                if (item != 0)
                {
                    var sql = "DELETE FROM [dbo].[WorkflowStage] WHERE Id = @Id";

                    connection.Execute(sql, new
                    {
                        Id = item
                    }, tran);
                }
            }

            if (workflow.Id == 0)
            {
                var sql = @"
                        INSERT INTO [dbo].[Workflows]
                       ([Name]
                       ,[GroupsThatCanStart])
		               OUTPUT INSERTED.Id
                       VALUES (@Name
                       ,@GroupsThatCanStart)
                        ";
                workflow.Id = connection.QuerySingle<int>(sql, workflow, tran);
            }
            else
            {
                var sql = @"UPDATE [dbo].[Workflows]
                        SET [Name] = @Name
                          ,[GroupsThatCanStart] = @GroupsThatCanStart
                        WHERE [Id] = @Id";

                connection.Execute(sql, workflow, tran);
            }

            foreach (var field in workflow.WorkflowFields)
            {
                if (field.Id == 0)
                {

                    field.WorkflowId = workflow.Id;
                    var sql = @"
                            INSERT INTO [dbo].[WorkflowFields]
                           ([WorkflowId]
                           ,[DisplayName]
                           ,[Code]
                           ,[Type]
                           ,[DisplayData]
                           ,[FieldType])
	                 OUTPUT inserted.Id
                     VALUES
                           (@WorkflowId
                           ,@DisplayName
                           ,@Code
                           ,@Type
                           ,@DisplayData
                           ,@FieldType)
                            ";

                    field.Id = connection.QuerySingle<int>(sql, field, tran);
                    newFieldCodes.Add(field.Code);
                }
                else
                {
                    var sql = @"
                            UPDATE [dbo].[WorkflowFields]
                               SET [WorkflowId] = @WorkflowId,
                                  [DisplayName] = @DisplayName,
                                  [Code] = @Code,
                                  [Type] = @Type,
                                  [DisplayData] = @DisplayData,
                                  [FieldType] = @FieldType
                             WHERE Id = @Id
                            ";

                    connection.Execute(sql, field, tran);
                }
            }

            foreach (var stage in workflow.WorkflowStage)
            {
                if (stage.StageIndex <= 0 || stage.StageIndex is null)
                    stage.StageIndex = workflow.WorkflowStage.IndexOf(stage) + 1;

                if (stage.Id == 0)
                {
                    stage.WorkflowId = workflow.Id;
                    var sql = @"
                        INSERT INTO [dbo].[WorkflowStage]
                                   ([Name]
                                   ,[AssignedEntityType]
                                   ,[AssignedEntityId]
                                   ,[StageIndex]
                                   ,[WorkflowId])
		                           OUTPUT inserted.Id
                             VALUES
                                   (@Name
                                   ,@AssignedEntityType
                                   ,@AssignedEntityId
                                   ,@StageIndex
                                   ,@WorkflowId)
                        ";

                    stage.Id = connection.QuerySingle<int>(sql, stage, tran);
                    newStageId.Add(stage.Id);
                }
                else
                {
                    var sql = @"
                            UPDATE [dbo].[WorkflowStage]
                               SET [Name] = @Name
                                  ,[AssignedEntityType] = @AssignedEntityType
                                  ,[AssignedEntityId] = @AssignedEntityId
                                  ,[StageIndex] = @StageIndex
                                  ,[WorkflowId] = @WorkflowId
                             WHERE Id = @Id";

                    connection.Execute(sql, stage, tran);

                }
            }

        }

        public List<Workflow> GetAll()
            => context.Workflows.AsNoTracking().Include(x => x.WorkflowFields)
            .Include(x => x.WorkflowStage)
            .ToList();

        public Workflow GetById(int id)
            => context.Workflows.AsNoTracking().Include(x => x.WorkflowFields)
            .Include(x => x.WorkflowStage)
            .First(x => x.Id == id);
    }

    public interface IWorkflowService : ISingleton
    {
        void DeleteChildren(List<int> deletedFieldsIds, List<int> deletedStagesIds);
        List<Workflow> GetAll();
        Workflow GetById(int id);
        List<WorkflowStageFieldModel> ReadStageFields(int workflowId);
        void UpdateStageFields(List<WorkflowStageFieldModel> stageFields);
        void Upsert(Workflow workflow, List<int> deletedFieldIds, List<int> deletedStagesIds);
    }
}
