namespace WorkflowManager.Api.Dtos
{
    public sealed class SetUserDiskLimitDto
    {
        public int UserId { get; set; }
        public int Limit { get; set; }
    }
}
