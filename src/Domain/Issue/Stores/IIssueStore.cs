namespace Domain.Issue.Stores
{
    public interface IIssueStore
    {
        Task<Issue?> Get(int id);
        Task<Issue> Update(Issue issue);
        Task<Issue> Register(Issue issue);
    }
}
