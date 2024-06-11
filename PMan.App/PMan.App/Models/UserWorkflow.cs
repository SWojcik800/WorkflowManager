using StorageManager.App.Commons;
using StorageManager.App.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace StorageManager.App.Models;

public partial class UserWorkflow : IEntity
{
    public int Id { get; set; }

    public int CreatedByUserId { get; set; }

    public int WorkflowId { get; set; }

    public int CurrentStageId { get; set; }
    public int WorkflowDictStatus { get; set; } = AppManager.Instance.Dictionaries.First(x => x.Name == "Statusy przepływów").DefaultItem.Id;
    [NotMapped]
    public string WorkflowDictStatusDisplayName { 
        get
        {
            var statusesDict = AppManager.Instance.Dictionaries.First(x => x.Name == "Statusy przepływów");

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
}

public enum UserWorkflowStatus
{
    New,
    Complete
}
