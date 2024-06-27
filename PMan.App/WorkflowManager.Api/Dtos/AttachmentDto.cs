namespace WorkflowManager.Api.Dtos
{
    public sealed class AttachmentDto
    {
        public string Id { get; set; }
        public string FileName { get; set; }
        public string CreatorLogin { get; set; }
        public int CreatedByUserId  { get; set; }
        public DateTime CreationTime  { get; set; }
    }
}
