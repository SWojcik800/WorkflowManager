using StorageManager.App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace WorkflowManager.App.Models
{
    public sealed class UserWorkflowHistoryEntry
    {
        private UserWorkflowHistoryEntry()
        {
            //For ef core
        }
        public UserWorkflowHistoryEntry(int userWorkflowId, string details, int actionUserId, ActionType actionType)
        {
            UserWorkflowId = userWorkflowId;
            Details = details;
            ActionUserId = actionUserId;
            ActionDate = DateTime.Now;
            ActionType = actionType;

            switch (ActionType)
            {
                case ActionType.CreatedByUser:
                    Title = "Utworzony przez użytkownika";
                    break;
                case ActionType.AssignedTo:
                    Title = "Aktywny etap przypisany do użytkownika";
                    break;
                case ActionType.ValuesUpdated:
                    Title = "Aktualizacja wartości";
                    break;
                case ActionType.ForwardedToNextStage:
                    Title = "Przekazany do następnego etapu";
                    break;
                case ActionType.GoBackToNextStage:
                    Title = "Cofnięty do poprzedniego etapu";
                    break;
                case ActionType.CompleteWorkflow:
                    Title = "Zakończony";
                    break;
                case ActionType.MoveToArchive:
                    Title = "Przeniesiono do archiwum";
                    break;
                default:
                    break;
            }
        }

        public int Id { get; set; }
        public int UserWorkflowId { get; set; }
        public UserWorkflow UserWorkflow { get; set; }
        public string Title { get; set; }
        public string Details { get; set; }
        public int ActionUserId { get; set; }
        public User ActionUser { get; set; }
        public DateTime ActionDate { get; set; }
        public ActionType ActionType { get; set; }
    }

    public enum ActionType
    {
        CreatedByUser,
        AssignedTo,
        ValuesUpdated,
        ForwardedToNextStage,
        GoBackToNextStage,
        CompleteWorkflow,
        MoveToArchive
    }
}
