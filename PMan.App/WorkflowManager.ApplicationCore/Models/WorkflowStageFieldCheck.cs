using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkflowManager.App.Models
{
    public sealed class WorkflowStageFieldCheck
    {
        public int WorkflowId { get; set; }
        public int Id { get; set; }
        public string Code { get; set; }
    }
}
