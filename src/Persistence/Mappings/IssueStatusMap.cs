using Domain.Issue;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Mappings
{
    internal static class IssueStatusMap
    {
        public static void Map(this EntityTypeBuilder<IssueStatus> builder)
        {
            builder.ToTable(nameof(IssueStatus));

            builder.HasKey(_ => _.Id);

            builder.HasKey(_ => _.Status);

            builder.Property(_ => _.CreateAt);
        }
    }
}
