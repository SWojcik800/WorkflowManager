using StorageManager.App.Commons;
using System;
using System.Collections.Generic;

namespace StorageManager.App.Models;

public partial class WorkflowStageField : IEntity
{
    public int Id { get; set; }
    public int WorkflowStageId { get; set; }
    public string FieldCode { get; set; } = null!;

    public bool IsVisible { get; set; }

    public bool IsEditable { get; set; }

    public bool IsRequired { get; set; }
}

public sealed class WorkflowStageFieldModel
{
    public int Id { get; set; }
    public int WorkflowStageId { get; set; }
    public string WorkflowStageName { get; set; }
    public string FieldCode { get; set; }

    public bool IsVisible { get; set; }

    public bool IsEditable { get; set; }

    public bool IsRequired { get; set; }
}

