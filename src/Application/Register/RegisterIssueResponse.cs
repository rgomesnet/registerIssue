using Domain.Issue;

namespace Application.Register
{
    public record RegisterIssueResponse
    {
        public int Code { get; init; } = default!;
        public string Description { get; init; } = default!;
        public string Owner { get; init; } = default!;
        public DateTime CreateAt { get; init; } = default!;
        public EIssueStatus CurrentStatus { get; init; } = default!;

        public static implicit operator RegisterIssueResponse(Issue issue)
            => new()
            {
                Code = issue.Id,
                Owner = issue.Owner,
                CreateAt = issue.CreateAt,
                Description = issue.Description,
                CurrentStatus = issue.Status.OrderBy(s => s.CreateAt).First().Status,
            };
    }
}