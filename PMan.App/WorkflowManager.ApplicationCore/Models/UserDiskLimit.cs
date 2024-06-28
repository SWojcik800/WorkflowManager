using StorageManager.App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkflowManager.ApplicationCore.Models
{
    public sealed class UserDiskLimit
    {
        public int Id { get; set; }
        public int Limit { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
