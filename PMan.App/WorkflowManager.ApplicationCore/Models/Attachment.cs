using StorageManager.App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkflowManager.ApplicationCore.Models
{
    public sealed class Attachment
    {
        public string Id { get; set; }
        public string FileName { get; set; }
        public string FilePath { get; set; }
        public int OwnerId { get; set; }
        public AttachmentOwnerType AttachmentOwnerType { get; set; }
        public DateTime CreationTime { get; set; }
        public int CreatedById { get; set; }
        public User CreatedBy { get; set; }
    }

    public enum AttachmentOwnerType
    {
        UserDisk,
        UserWorkflow
    }
}
