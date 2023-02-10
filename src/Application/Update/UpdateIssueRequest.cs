using Domain.Issue;

namespace Application.Update
{
    public record UpdateIssueRequest
    {
        public int Code { get; init; } = default!;
        public EIssueStatus NewStatus { get; init; } = default!;
    }
}
