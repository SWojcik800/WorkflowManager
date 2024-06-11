using Microsoft.EntityFrameworkCore;
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


            foreach (var item in userWorkflows)
            {
                var model = new UserWorkflowReadModel();
                model.Id = item.Id;
                var workflow = workflows.FirstOrDefault(x => x.Id == item.WorkflowId);

                if (workflow is not null)
                { 
                    model.Name = workflow.Name;

                    var currentStage = workflow.WorkflowStage.FirstOrDefault(x => x.Id == item.CurrentStageId);

                    if(currentStage is not null)
                    {
                        model.Stage = currentStage.Name;
                    }
                }
                var dictStatus = statuses.DictionaryItems.FirstOrDefault(x => x.Id == item.WorkflowDictStatus);

                if(dictStatus is not null)
                {
                    model.DictStatus = dictStatus.Name;
                }

                if(item.CurrentStageAssignedToUserId is not null)
                {
                    var user = users.FirstOrDefault(x => x.Id == item.CurrentStageAssignedToUserId);

                    if (user is not null)
                        model.AssignedToUser = user.Login;
                }

                readModels.Add(model);
            }

            return readModels;
        }
    }

    public interface IUserWorkflowService : ISingleton
    {
        void CreateUserWorkflow(int workflowId, int userId);
        List<UserWorkflowReadModel> ListUserCreatedWorkflows();
    }
}
