using Domain.Issue.EventFeed;
using Domain.Issue.Stores;

namespace Application.Update
{
    public class UpdateIssue : IUpdateIssue
    {
        private readonly IIssueStore _store;
        private readonly IEventPublisher _eventPublisher;

        public UpdateIssue(IIssueStore store, IEventPublisher eventPublisher)
            => (_store, _eventPublisher) = (store, eventPublisher);

        public async Task<UpdateIssueResponse> Execute(UpdateIssueRequest request)
        {
            var issue = await _store.Get(request.Code);

            issue.AddStatus(request.NewStatus);

            issue = await _store.Update(issue);

            await _eventPublisher.Raise(issue);

            UpdateIssueResponse response = issue;

            return response;
        }
    }
}
