using StorageManager.App.Commons;
using StorageManager.App.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using WorkflowManager.App.Models;

namespace StorageManager.App.Models;

public partial class UserWorkflow : IEntity
{
    public int Id { get; set; }

    public int CreatedByUserId { get; set; }

    public int WorkflowId { get; set; }
    public Workflow Workflow { get; set; }

    public int CurrentStageId { get; set; }
    public WorkflowStage CurrentStage { get; set; }
    public int WorkflowDictStatus { get; set; } = AppManagerCore.Instance.Dictionaries.First(x => x.Name == "Statusy przepływów").DefaultItem.Id;
    [NotMapped]
    public string WorkflowDictStatusDisplayName { 
        get
        {
            var statusesDict = AppManagerCore.Instance.Dictionaries.First(x => x.Name == "Statusy przepływów");

            if(WorkflowDictStatus == 0)
                return statusesDict.DefaultItem is not null ? statusesDict.DefaultItem.Name : "";

            return statusesDict.DictionaryItems.First(x => x.Id == WorkflowDictStatus).Name;
        }
    }

    public DateTime CreationTime { get; set; }

    public UserWorkflowStatus Status { get; set; }

    public DateTime? CompletionTime { get; set; }

    public int? CurrentStageAssignedToUserId { get; set; }

    public virtual ICollection<UserWorkflowFieldValue> UserWorkflowFieldValues { get; set; } = new List<UserWorkflowFieldValue>();
    public virtual ICollection<UserWorkflowHistoryEntry> HistoryEntries { get; set; } = new List<UserWorkflowHistoryEntry>();
}

public enum UserWorkflowStatus
{
    New,
    Complete
}
