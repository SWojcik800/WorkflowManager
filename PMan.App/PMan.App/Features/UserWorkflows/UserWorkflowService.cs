using StorageManager.App.Commons.IoC;
using StorageManager.App.Database;
using StorageManager.App.Features.Users;
using StorageManager.App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkflowManager.App.Features.Workflows;

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
    }

    public interface IUserWorkflowService : ISingleton
    {
        void CreateUserWorkflow(int workflowId, int userId);
    }
}
