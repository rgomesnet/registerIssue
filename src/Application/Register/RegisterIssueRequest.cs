using Domain.Issue;

namespace Application.Register
{
    public record RegisterIssueRequest
    {
        public string Owner { get; init; } = default!;
        public string Description { get; init; } = default!;

        public static implicit operator Issue(RegisterIssueRequest request)
            => new()
            {
                Description = request.Description,
                Owner = request.Owner
            };
    }
}