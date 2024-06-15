using Dapper;
using Microsoft.EntityFrameworkCore;
using StorageManager.App.Commons;
using StorageManager.App.Commons.IoC;
using StorageManager.App.Database;
using StorageManager.App.Features.Users;
using StorageManager.App.Helpers;
using StorageManager.App.Models;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkflowManager.App.Features.Workflows;
using WorkflowManager.App.Models;

namespace WorkflowManager.App.Features.UserWorkflows
{
    internal sealed class UserWorkflowService(AppDbContext context, IUserService userService, IWorkflowService workflowService) : IUserWorkflowService
    {
        public void CreateUserWorkflow(int workflowId, int userId)
        {
            var workflow = workflowService.GetById(workflowId);
            var user = userService.GetById(userId);

            var firstStage = workflow.WorkflowStage.OrderBy(x => x.StageIndex).First();

            var userWorkflow = new UserWorkflow()
            {
                WorkflowId = workflowId,
                CreatedByUserId = userId,
                CreationTime = DateTime.Now,
                CurrentStageAssignedToUserId = null,
                Status = UserWorkflowStatus.New,
                CurrentStageId = firstStage.Id
            };

            userWorkflow.HistoryEntries.Add(new UserWorkflowHistoryEntry(userWorkflow.Id, "", userId, ActionType.CreatedByUser));

            context.Add(userWorkflow);
            context.SaveChanges();

        }

        public List<UserWorkflowReadModel> ListUserCreatedWorkflows()
        {
            var userWorkflows = context.UserWorkflows.Where(x => x.CreatedByUserId == userService.CurrentUser.Id).ToList();
            var workflows = context.Workflows.Include(x => x.WorkflowStage).ToList();
            var statuses = AppManager.Instance.Dictionaries.First(x => x.Name == "Statusy przepływów");
            var users = AppManager.Instance.Users;

            var readModels = new List<UserWorkflowReadModel>();
            MapUserWorkflowsToReadModel(userWorkflows, workflows, statuses, users, readModels);

            return readModels;
        }

        private static void MapUserWorkflowsToReadModel(List<UserWorkflow> userWorkflows, List<Workflow> workflows, Dictionary statuses, List<User> users, List<UserWorkflowReadModel> readModels)
        {
            foreach (var item in userWorkflows)
            {
                var model = new UserWorkflowReadModel();
                model.Id = item.Id;
                model.AssignedToUserId = item.CurrentStageAssignedToUserId;
                var workflow = workflows.FirstOrDefault(x => x.Id == item.WorkflowId);

                if (workflow is not null)
                {
                    model.Name = workflow.Name;
                    model.WorkflowId = workflow.Id;

                    var currentStage = workflow.WorkflowStage.FirstOrDefault(x => x.Id == item.CurrentStageId);

                    if (currentStage is not null)
                    {
                        model.Stage = currentStage.Name;
                        model.CurrentStageId = currentStage.Id;
                    }
                }
                //var dictStatus = statuses.DictionaryItems.FirstOrDefault(x => x.Id == item.WorkflowDictStatus);

                //if (dictStatus is not null)
                //{
                //    model.DictStatus = dictStatus.Name;
                //}

                model.DictStatus = item.Status == UserWorkflowStatus.Complete ? "Zakończony" : "W trakcie";

                if (item.CurrentStageAssignedToUserId is not null)
                {
                    var user = users.FirstOrDefault(x => x.Id == item.CurrentStageAssignedToUserId);

                    if (user is not null)
                        model.AssignedToUser = user.Login;
                }


                readModels.Add(model);
            }
        }

        public List<UserWorkflowReadModel> StagesToProcess()
        {
            var currentUser = userService.CurrentUser;
            using (var connection = DbConnectionFactory.Create())
            {
                connection.Open();
                var groups = AppManager.Instance.Dictionaries.First(x => x.Name == "Grupy użytkowników").DictionaryItems;
                var currentUserGroups = groups.Where(g => AppManager.Instance.CurrentUser.GroupList().Contains(g.Value)).Select(x => x.Id).ToArray();


                var sql = @"
                SELECT uw.Id
                  FROM UserWorkflows uw
                  join WorkflowStage ws on uw.CurrentStageId = ws.Id
                  where uw.Status = 0 AND ( uw.CurrentStageAssignedToUserId IS NULL OR uw.CurrentStageAssignedToUserId = @CurrentUserId )
                  AND (
                  (ws.AssignedEntityType = 0 AND uw.CreatedByUserId = @CurrentUserId)
                  OR (ws.AssignedEntityType = 1 AND ws.AssignedEntityId IN @CurrentUserGroupIds)
                  OR (ws.AssignedEntityType = 2 AND ws.AssignedEntityId = @CurrentUserId)
                  OR uw.CurrentStageAssignedToUserId = @CurrentUserId
                  )
                ";

                var userWorkflowIds = connection.Query<int>(sql, new
                {
                    CurrentUserId = currentUser.Id,
                    CurrentUserGroupIds = currentUserGroups
                });

                var workflows = context.Workflows.Include(x => x.WorkflowStage).ToList();
                var statuses = AppManager.Instance.Dictionaries.First(x => x.Name == "Statusy przepływów");
                var users = AppManager.Instance.Users;

                var readModels = new List<UserWorkflowReadModel>();

                var userWorkflows = context.UserWorkflows.Where(x => userWorkflowIds.Contains(x.Id)).ToList();
                MapUserWorkflowsToReadModel(userWorkflows, workflows, statuses, users, readModels);

                return readModels;
            }



        }

        public Result<int> AssignToCurrentUser(int userWorkflowId, int stageId)
        {
            var userWorkflow = context.UserWorkflows.FirstOrDefault(x => x.Id == userWorkflowId && x.CurrentStageId == stageId);

            if (userWorkflow is null)
                return Result<int>.Fail("Nie znaleziono etapu");

            if(userWorkflow.CurrentStageAssignedToUserId is not null)
            {
                return Result<int>.Fail("Etap został już przypisany do danego użytkownika");
            }

            using (var connection = DbConnectionFactory.Create())
            {
                connection.Open();

                connection.Execute("UPDATE UserWorkflows SET CurrentStageAssignedToUserId = @CurrentUserId WHERE Id = @UserWorkflowId AND CurrentStageId = @CurrentStageId", new
                {
                    CurrentUserId = userService.CurrentUser.Id,
                    UserWorkflowId = userWorkflow.Id,
                    CurrentStageId = userWorkflow.CurrentStageId
                });
               
                InsertHistoryEntry(connection, new UserWorkflowHistoryEntry(userWorkflowId, $"ZMIANA OSOBY PRZYPISANEJ NA {userService.CurrentUser.Login}", userService.CurrentUser.Id, ActionType.AssignedTo));
            }


            //context.UserWorkflows.Update(userWorkflow);
            //context.SaveChanges();

            return Result<int>.Success(userWorkflowId);
        }

        public UserWorkflow GetById(int id)
        {
            var userWorkflow = context.UserWorkflows
                .Include(x => x.Workflow)
                .ThenInclude(x => x.WorkflowFields)
                .Include(x => x.UserWorkflowFieldValues)
                .Include(x => x.HistoryEntries)
                .First(x => x.Id == id);

            var currentStage = context.WorkflowStages.AsNoTracking().Include(x => x.StageFields).FirstOrDefault(x => x.Id == userWorkflow.CurrentStageId);
            userWorkflow.CurrentStage = currentStage;


            return userWorkflow;
        }

        public void CompleteWorkflow(UserWorkflow userWorkflow)
        {
            userWorkflow.CompletionTime = DateTime.Now;
            userWorkflow.Status = UserWorkflowStatus.Complete;

            using (var connection = DbConnectionFactory.Create())
            {
                connection.Open();

                connection.Execute("UPDATE UserWorkflows SET Status = 1, CompletionTime = @Now WHERE Id = @UserWorkflowId", new
                {
                    UserWorkflowId = userWorkflow.Id,
                    Now = DateTime.Now
                });

                CheckForValueChanges(userWorkflow);
                InsertHistoryEntry(connection, new UserWorkflowHistoryEntry(userWorkflow.Id, "", userService.CurrentUser.Id, ActionType.CompleteWorkflow));
            }
        }

        public void ForwardToNextStage(UserWorkflow userWorkflow)
        {
            var stageIdx = userWorkflow.CurrentStage.StageIndex;
            var nextStage = userWorkflow.Workflow.WorkflowStage.Where(x => x.StageIndex > stageIdx)
                .OrderBy(x => x.StageIndex)
                .FirstOrDefault();

            CheckForValueChanges(userWorkflow);
            userWorkflow.HistoryEntries.Add(new UserWorkflowHistoryEntry(userWorkflow.Id, $"ORYGINALNY ETAP: {userWorkflow.CurrentStage.Name} PRZEKAZANO DO: {nextStage?.Name}", userService.CurrentUser.Id, ActionType.GoBackToNextStage));

            if (nextStage is not null)
            {
                userWorkflow.CurrentStage = nextStage;
                userWorkflow.CurrentStageId = nextStage.Id;
                userWorkflow.CurrentStageAssignedToUserId = null;
            }

            context.UserWorkflows.Update(userWorkflow);
            context.SaveChanges();
        }

        public void GoBackToPreviousStage(UserWorkflow userWorkflow)
        {
            var stageIdx = userWorkflow.CurrentStage.StageIndex;
            var previousStage = userWorkflow.Workflow.WorkflowStage.Where(x => x.StageIndex < stageIdx)
                .OrderByDescending(x => x.StageIndex)
                .FirstOrDefault();

            CheckForValueChanges(userWorkflow);
            userWorkflow.HistoryEntries.Add(new UserWorkflowHistoryEntry(userWorkflow.Id, $"ORYGINALNY ETAP: {userWorkflow.CurrentStage.Name} COFNIĘTO DO: {previousStage?.Name}", userService.CurrentUser.Id, ActionType.GoBackToNextStage));

            if (previousStage is not null)
            {
                userWorkflow.CurrentStage = previousStage;
                userWorkflow.CurrentStageId = previousStage.Id;
                userWorkflow.CurrentStageAssignedToUserId = null;
            }

            context.UserWorkflows.Update(userWorkflow);
            context.SaveChanges();
        }

        private void CheckForValueChanges(UserWorkflow userWorkflow)
        {
            var originalWorkflowValues = context.UserWorkflowFieldValues.AsNoTracking().Where(x => x.UserWorkflowId == userWorkflow.Id).ToList();

            if (originalWorkflowValues is null)
                return;

            var valueChanges = new List<ValueChanges>();

            foreach (var entry in userWorkflow.UserWorkflowFieldValues)
            {
                var org = originalWorkflowValues.FirstOrDefault(x => x.FieldCode == entry.FieldCode);

                if(org is null)
                {
                    valueChanges.Add(new ValueChanges() { Field = entry.FieldCode, OldValue = "", NewValue = entry.FieldValue });
                } else if(org.FieldValue != entry.FieldValue)
                {
                    valueChanges.Add(new ValueChanges() { Field = entry.FieldCode, OldValue = org.FieldValue, NewValue = entry.FieldValue });
                }               
            }

            if(valueChanges.Any())
            {
                var valueChangesStr = "";

                foreach (var change in valueChanges)
                {
                    valueChangesStr += $"ORYGINALNA WARTOŚĆ: '{change.OldValue}' \n NOWA WARTOSC: '{change.NewValue}'\n";
                }

                userWorkflow.HistoryEntries.Add(new UserWorkflowHistoryEntry(userWorkflow.Id, valueChangesStr, userService.CurrentUser.Id, ActionType.ValuesUpdated));

            }



        }

        private void InsertHistoryEntry(DbConnection connection , UserWorkflowHistoryEntry historyEntry)
        {
            connection.Execute("INSERT INTO [dbo].[UserWorkflowHistoryEntries] ([UserWorkflowId],[Title],[Details],[ActionUserId],[ActionDate],[ActionType]) VALUES (@UserWorkflowId ,@Title ,@Details ,@ActionUserId ,@ActionDate ,@ActionType)",
                historyEntry);
        }

    }

    public interface IUserWorkflowService : ISingleton
    {
        Result<int> AssignToCurrentUser(int userWorkflowId, int stageId);
        void CompleteWorkflow(UserWorkflow userWorkflow);
        void CreateUserWorkflow(int workflowId, int userId);
        void ForwardToNextStage(UserWorkflow userWorkflow);
        UserWorkflow GetById(int id);
        void GoBackToPreviousStage(UserWorkflow userWorkflow);
        List<UserWorkflowReadModel> ListUserCreatedWorkflows();
        List<UserWorkflowReadModel> StagesToProcess();
    }
}
