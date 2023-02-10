namespace Domain.Issue
{
    public record IssueStatus
    {
        public int Id { get; init; } = default!;
        public EIssueStatus Status { get; init; } = EIssueStatus.Opened;
        public DateTime CreateAt { get; init; } = DateTime.UtcNow;
    }
}
