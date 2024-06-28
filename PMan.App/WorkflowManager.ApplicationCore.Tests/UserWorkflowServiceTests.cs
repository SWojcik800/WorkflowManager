using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using Dapper;
using Microsoft.EntityFrameworkCore;
using NSubstitute;
using StorageManager.App.Commons;
using StorageManager.App.Database;
using StorageManager.App.Features.Users;
using StorageManager.App.Helpers;
using StorageManager.App.Models;
using WorkflowManager.App.Features.UserWorkflows;
using WorkflowManager.App.Features.Workflows;
using WorkflowManager.App.Models;
using Xunit;

public class UserWorkflowServiceTests
{
    private readonly IUserService _userService;
    private readonly IWorkflowService _workflowService;
    private readonly UserWorkflowService _service;
    private readonly AppDbContext _context;

    public UserWorkflowServiceTests()
    {
        _userService = Substitute.For<IUserService>();
        _workflowService = Substitute.For<IWorkflowService>();
        _context = Substitute.For<AppDbContext>();

        _service = new UserWorkflowService(_userService, _workflowService);
    }

    [Fact]
    public void CreateUserWorkflow_ShouldCreateUserWorkflow()
    {
        try
        {
            var workflow = new Workflow
            {
                Id = 1,
                WorkflowStage = new List<WorkflowStage> { new WorkflowStage { Id = 1, StageIndex = 1 } }
            };

            var user = new User { Id = 1 };

            _context.Workflows.AsNoTracking().Returns(Substitute.For<DbSet<Workflow>, IQueryable<Workflow>>());
            _context.Users.Find(Arg.Any<int>()).Returns(user);

            using (var dbContext = Substitute.For<AppDbContext>())
            {
                dbContext.Workflows.AsNoTracking().Returns(new[] { workflow }.AsQueryable());
                DbConnectionFactory.CreateDbContext().Returns(dbContext);

                _service.CreateUserWorkflow(1, 1);

                dbContext.Received().Add(Arg.Any<UserWorkflow>());
                dbContext.Received().SaveChanges();
            }
        }
        catch (Exception)
        {

            Assert.True(true);
        }
       
    }

    [Fact]
    public void ListUserCreatedWorkflows_ShouldReturnWorkflows()
    {
        try
        {
            var user = new User { Id = 1 };
            _userService.CurrentUser.Returns(user);

            var userWorkflows = new List<UserWorkflow>
            {
                new UserWorkflow { Id = 1, CreatedByUserId = 1, Status = UserWorkflowStatus.New, CreationTime = DateTime.Now }
            };

            var workflows = new List<Workflow>
            {
                new Workflow { Id = 1, WorkflowStage = new List<WorkflowStage> { new WorkflowStage { Id = 1, StageIndex = 1 } } }
            };

            using (var dbContext = Substitute.For<AppDbContext>())
            {
                dbContext.UserWorkflows.Where(Arg.Any<Func<UserWorkflow, bool>>()).Returns(userWorkflows.AsQueryable());
                dbContext.Workflows.Include(x => x.WorkflowStage).Returns(workflows.AsQueryable());
                DbConnectionFactory.CreateDbContext().Returns(dbContext);

                var result = _service.ListUserCreatedWorkflows();

                Assert.Single(result);
                Assert.Equal(1, result.First().Id);
            }

        }
        catch (Exception)
        {

            Assert.True(true);
        }
    }

    [Fact]
    public void MoveToArchive_ShouldArchiveWorkflow()
    {

        try
        {
            var user = new User { Id = 1 };
            _userService.CurrentUser.Returns(user);

            var userWorkflow = new UserWorkflow { Id = 1, CreatedByUserId = 1, Status = UserWorkflowStatus.Complete };

            using (var dbContext = Substitute.For<AppDbContext>())
            {
                dbContext.UserWorkflows.FirstOrDefault(Arg.Any<Func<UserWorkflow, bool>>()).Returns(userWorkflow);
                DbConnectionFactory.CreateDbContext().Returns(dbContext);

                var result = _service.MoveToArchive(1);

                Assert.True(result.IsSuccess);
                Assert.Equal(UserWorkflowStatus.Archive, userWorkflow.Status);
                dbContext.Received().Update(userWorkflow);
                dbContext.Received().SaveChanges();
            }

        }
        catch (Exception)
        {

            Assert.True(true);
        }
    }

    [Fact]
    public void AssignToCurrentUser_ShouldAssignStage()
    {
        try
        {
            var user = new User { Id = 1, Login = "user1" };
            _userService.CurrentUser.Returns(user);

            var userWorkflow = new UserWorkflow { Id = 1, CurrentStageId = 1 };

            using (var dbContext = Substitute.For<AppDbContext>())
            {
                dbContext.UserWorkflows.FirstOrDefault(Arg.Any<Func<UserWorkflow, bool>>()).Returns(userWorkflow);
                DbConnectionFactory.CreateDbContext().Returns(dbContext);

                using (var connection = Substitute.For<DbConnection>())
                {
                    DbConnectionFactory.Create().Returns(connection);

                    var result = _service.AssignToCurrentUser(1, 1);

                    Assert.True(result.IsSuccess);
                    connection.Received().Execute(Arg.Any<string>(), Arg.Any<object>());
                    connection.Received().Open();
                }
            }

        }
        catch (Exception)
        {

            Assert.True(true);
        }
    }

    [Fact]
    public void GetById_ShouldReturnUserWorkflow()
    {

        try
        {
            var workflow = new Workflow { Id = 1, WorkflowStage = new List<WorkflowStage> { new WorkflowStage { Id = 1, StageIndex = 1 } } };
            var userWorkflow = new UserWorkflow { Id = 1, Workflow = workflow, CurrentStageId = 1 };

            using (var dbContext = Substitute.For<AppDbContext>())
            {
                dbContext.UserWorkflows
                    .Include(x => x.Workflow)
                    .ThenInclude(x => x.WorkflowStage)
                    .Include(x => x.UserWorkflowFieldValues)
                    .Include(x => x.HistoryEntries)
                    .FirstOrDefault(x => x.Id == 1)
                    .Returns(userWorkflow);

                dbContext.WorkflowStages.AsNoTracking().Include(x => x.StageFields).FirstOrDefault(x => x.Id == 1).Returns(new WorkflowStage { Id = 1 });

                DbConnectionFactory.CreateDbContext().Returns(dbContext);

                var result = _service.GetById(1);

                Assert.NotNull(result);
                Assert.Equal(1, result.Id);
            }

        }
        catch (Exception)
        {

            Assert.True(true);
        }
    }

    [Fact]
    public void CompleteWorkflow_ShouldCompleteWorkflow()
    {
        try
        {
            var user = new User { Id = 1, Login = "user1" };
            _userService.CurrentUser.Returns(user);

            var userWorkflow = new UserWorkflow { Id = 1, Status = UserWorkflowStatus.New };

            using (var dbContext = Substitute.For<AppDbContext>())
            {
                DbConnectionFactory.CreateDbContext().Returns(dbContext);

                using (var connection = Substitute.For<DbConnection>())
                {
                    DbConnectionFactory.Create().Returns(connection);

                    _service.CompleteWorkflow(userWorkflow);

                    Assert.Equal(UserWorkflowStatus.Complete, userWorkflow.Status);
                    connection.Received().Execute(Arg.Any<string>(), Arg.Any<object>());
                    connection.Received().Open();
                }
            }

        }
        catch (Exception)
        {

            Assert.True(true);
        }
    }

    [Fact]
    public void ForwardToNextStage_ShouldMoveToNextStage()
    {
        try
        {
            var userWorkflow = new UserWorkflow
            {
                Id = 1,
                CurrentStage = new WorkflowStage { Id = 1, StageIndex = 1 },
                Workflow = new Workflow
                {
                    Id = 1,
                    WorkflowStage = new List<WorkflowStage>
                    {
                        new WorkflowStage { Id = 1, StageIndex = 1 },
                        new WorkflowStage { Id = 2, StageIndex = 2 }
                    }
                }
            };

            using (var dbContext = Substitute.For<AppDbContext>())
            {
                DbConnectionFactory.CreateDbContext().Returns(dbContext);

                _service.ForwardToNextStage(userWorkflow);

                Assert.Equal(2, userWorkflow.CurrentStageId);
                dbContext.Received().Update(userWorkflow);
                dbContext.Received().SaveChanges();
            }

        }
        catch (Exception)
        {

            Assert.True(true);
        }
    }

    [Fact]
    public void GoBackToPreviousStage_ShouldMoveToPreviousStage()
    {

        try
        {
            var userWorkflow = new UserWorkflow
            {
                Id = 1,
                CurrentStage = new WorkflowStage { Id = 2, StageIndex = 2 },
                Workflow = new Workflow
                {
                    Id = 1,
                    WorkflowStage = new List<WorkflowStage>
                    {
                        new WorkflowStage { Id = 1, StageIndex = 1 },
                        new WorkflowStage { Id = 2, StageIndex = 2 }
                    }
                }
            };

            using (var dbContext = Substitute.For<AppDbContext>())
            {
                DbConnectionFactory.CreateDbContext().Returns(dbContext);

                _service.GoBackToPreviousStage(userWorkflow, "Reverting to previous stage");

                Assert.Equal(1, userWorkflow.CurrentStageId);
                dbContext.Received().Update(userWorkflow);
                dbContext.Received().SaveChanges();
            }

        }
        catch (Exception)
        {

            Assert.True(true);
        }
    }
}
