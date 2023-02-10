using Domain.Issue;
using Domain.Issue.EventFeed;
using Domain.Issue.Stores;

namespace Application.Register
{
    public class RegisterIssue : IRegisterIssue
    {
        private readonly IIssueStore _store;
        private readonly IEventPublisher _eventPublisher;

        public RegisterIssue(IIssueStore store, IEventPublisher eventPublisher)
            => (_store, _eventPublisher) = (store, eventPublisher);

        public async Task<RegisterIssueResponse> Execute(RegisterIssueRequest request)
        {
            Issue issue = request;

            issue.AddStatus(EIssueStatus.Opened);

            issue = await _store.Register(issue);

            await _eventPublisher.Raise(issue);

            RegisterIssueResponse response = issue;

            return response;
        }
    }
}