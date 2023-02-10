namespace Application.Update
{
    public interface IUpdateIssue
    {
        Task<UpdateIssueResponse> Execute(UpdateIssueRequest issue);
    }
}
