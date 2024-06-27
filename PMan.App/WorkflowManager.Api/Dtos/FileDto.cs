namespace WorkflowManager.Api.Dtos
{
    public sealed class FileDto
    {
        public string Id { get; set; }
        public string FileName { get; set; }
        public byte[] File { get; set; }
    }
}
