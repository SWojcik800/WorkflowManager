using StorageManager.App.Helpers;
using StorageManager.App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkflowManager.App.Models
{
    public class UserHistoryEntryReadModel
    {
        public UserHistoryEntryReadModel()
        {
            
        }
        public UserHistoryEntryReadModel(UserWorkflowHistoryEntry entry)
        {
            Id = entry.Id;
            Title = entry.Title;
            Details = entry.Details;
            UserWorkflowId = entry.UserWorkflowId;
            ActionUserId = entry.ActionUserId;
            var actionUser = AppManagerCore.Instance.Users.FirstOrDefault(x => x.Id == ActionUserId);

            if(actionUser is not null)
            {
                ActionUserLogin = actionUser.Login;
            }

            ActionDate = entry.ActionDate;
        }
        public int Id { get; set; }
        public int UserWorkflowId { get; set; }
        public string Title { get; set; }
        public string Details { get; set; }
        public int ActionUserId { get; set; }
        public string ActionUserLogin { get; set; }
        public DateTime ActionDate { get; set; }
    }
}
