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
                var dictStatus = statuses.DictionaryItems.FirstOrDefault(x => x.Id == item.WorkflowDictStatus);

                if (dictStatus is not null)
                {
                    model.DictStatus = dictStatus.Name;
                }

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
                .First(x => x.Id == id);

            var currentStage = context.WorkflowStages.AsNoTracking().Include(x => x.StageFields).FirstOrDefault(x => x.Id == userWorkflow.CurrentStageId);
            userWorkflow.CurrentStage = currentStage;


            return userWorkflow;
        }

        public void CompleteWorkflow(UserWorkflow userWorkflow)
        {
            userWorkflow.CompletionTime = DateTime.Now;
            userWorkflow.Status = UserWorkflowStatus.Complete;

            context.UserWorkflows.Update(userWorkflow);
            context.SaveChanges();
        }

        public void ForwardToNextStage(UserWorkflow userWorkflow)
        {
            var stageIdx = userWorkflow.CurrentStage.StageIndex;
            var nextStage = userWorkflow.Workflow.WorkflowStage.Where(x => x.StageIndex > stageIdx)
                .OrderBy(x => x.StageIndex)
                .FirstOrDefault();

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

            if (previousStage is not null)
            {
                userWorkflow.CurrentStage = previousStage;
                userWorkflow.CurrentStageId = previousStage.Id;
                userWorkflow.CurrentStageAssignedToUserId = null;
            }

            context.UserWorkflows.Update(userWorkflow);
            context.SaveChanges();
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
