using Domain.Issue;
using Microsoft.EntityFrameworkCore;
using Persistence.Mappings;

namespace Persistence
{
    internal class IssueContext : DbContext
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Issue>().Map();
            modelBuilder.Entity<IssueStatus>().Map();
        }
    }
}
