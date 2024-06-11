using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkflowManager.App.Models
{
    public sealed class UserWorkflowReadModel
    {
        public UserWorkflowReadModel()
        {
            
        }
        public UserWorkflowReadModel(int id, string name, string dictStatus, string stage, string assignedToUser)
        {
            Id = id;
            Name = name;
            DictStatus = dictStatus;
            Stage = stage;
            AssignedToUser = assignedToUser;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string DictStatus { get; set; }
        public string Stage { get; set; }
        public string AssignedToUser { get; set; }
    }
}
