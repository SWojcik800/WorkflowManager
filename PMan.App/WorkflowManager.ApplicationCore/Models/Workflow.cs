using StorageManager.App.Commons;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace StorageManager.App.Models;

public partial class Workflow : IEntity
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public List<WorkflowField> WorkflowFields { get; set; } = new List<WorkflowField>();
    public List<WorkflowStage> WorkflowStage { get; set; } = new List<WorkflowStage>();

    [NotMapped]
    public int WorkflowFieldsCount {
        get { return WorkflowFields.Count(); }
    }

    [NotMapped]
    public int WorkflowStageCount
    {
        get { return WorkflowStage.Count(); }
    }

    public string GroupsThatCanStart { get; set; }
    public List<string> GetGroupsThatCanStart()
        => string.IsNullOrEmpty(GroupsThatCanStart) ? new() : GroupsThatCanStart.Split(";").ToList();
}
