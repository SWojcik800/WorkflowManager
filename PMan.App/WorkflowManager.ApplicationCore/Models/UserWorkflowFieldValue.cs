using StorageManager.App.Commons;
using System;
using System.Collections.Generic;

namespace StorageManager.App.Models;

public partial class UserWorkflowFieldValue : IEntity
{
    public int Id { get; set; }

    public string FieldCode { get; set; } = null!;

    public string? FieldValue { get; set; }

    public int UserWorkflowId { get; set; }

    public virtual UserWorkflow UserWorkflow { get; set; } = null!;
}
