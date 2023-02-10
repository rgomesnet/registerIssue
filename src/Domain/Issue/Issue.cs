namespace Domain.Issue
{
    public class Issue
    {
        private readonly ICollection<IssueStatus> _status = new List<IssueStatus>();

        public int Id { get; init; } = default!;
        public string Description { get; init; } = default!;
        public string Owner { get; init; } = default!;
        public DateTime CreateAt { get; init; } = DateTime.UtcNow;
        public IReadOnlyCollection<IssueStatus> Status => _status.ToList();

        public void AddStatus(EIssueStatus status)
        {
            if (!IsChangeStatusAllowed(status))
            {
                throw new InvalidOperationException("It is not allowed to change the status.");
            }

            _status.Add(new IssueStatus
            {
                Status = status
            });
        }

        private bool IsChangeStatusAllowed(EIssueStatus status)
        {
            var lastStatus = _status.OrderBy(s => s.CreateAt).LastOrDefault();

            return status switch
            {
                EIssueStatus.Opened => lastStatus is not null,
                EIssueStatus.Processing => (!lastStatus?.Status.Equals(EIssueStatus.Opened) ?? false),
                _ => (!lastStatus?.Status.Equals(EIssueStatus.Processing) ?? false),
            };
        }
    }
}