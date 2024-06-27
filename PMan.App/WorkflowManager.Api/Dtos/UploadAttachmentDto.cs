using WorkflowManager.ApplicationCore.Models;

namespace WorkflowManager.Api.Dtos
{
    public class UploadAttachmentDto
    {
        public byte[] Attachment { get; set; }
        public string FileName { get; set; }
        public AttachmentOwnerType AttachmentOwnerType { get; set; }
        public int OwnerId { get; set; }
    }
}
