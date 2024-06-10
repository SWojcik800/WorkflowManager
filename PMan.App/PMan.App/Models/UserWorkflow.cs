using StorageManager.App.Commons;
using System;
using System.Collections.Generic;

namespace StorageManager.App.Models;

public partial class UserWorkflow : IEntity
{
    public int Id { get; set; }

    public int CreatedByUserId { get; set; }

    public int WorkflowId { get; set; }

    public int CurrentStageId { get; set; }

    public DateTime CreationTime { get; set; }

    public UserWorkflowStatus Status { get; set; }

    public DateTime? CompletionTime { get; set; }

    public int? CurrentStageAssignedToUserId { get; set; }

    public virtual ICollection<UserWorkflowFieldValue> UserWorkflowFieldValues { get; set; } = new List<UserWorkflowFieldValue>();
}

public enum UserWorkflowStatus
{
    New,
    Complete
}
