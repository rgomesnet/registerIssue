using Domain.Issue;
using Domain.Issue.Stores;
using Microsoft.EntityFrameworkCore;

namespace Persistence
{
    internal class IssueStore : IIssueStore
    {
        private readonly IssueContext _context;
        public IssueStore(IssueContext context)
        {
            _context = context;
        }

        public async Task<Issue?> Get(int id)
        {
            return await _context.Set<Issue>().FirstOrDefaultAsync(i => i.Id == id);
        }

        public async Task<Issue> Register(Issue issue)
        {
            _context.Set<Issue>().Add(issue);
            await _context.SaveChangesAsync();
            return issue;
        }

        public async Task<Issue> Update(Issue issue)
        {
            await _context.SaveChangesAsync();
            return issue;
        }
    }
}