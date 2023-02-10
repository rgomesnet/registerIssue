namespace Application.Register
{
    public interface IRegisterIssue
    {
        Task<RegisterIssueResponse> Execute(RegisterIssueRequest issue);
    }
}