namespace Domain.Issue.EventFeed
{
    public interface IEventPublisher
    {
        Task Raise(Issue issue);
    }
}
