using Domain.Issue;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Mappings
{
    internal static class IssueMap
    {
        public static void Map(this EntityTypeBuilder<Issue> builder)
        {
            builder.ToTable(nameof(Issue));

            builder.HasKey(_ => _.Id);

            builder.Property(_ => _.Owner);

            builder.Property(_ => _.Description);

            builder.Property(_ => _.CreateAt);

#pragma warning disable CS8602 // Dereference of a possibly null reference.
            builder.Metadata.FindNavigation("_status")
                .SetPropertyAccessMode(PropertyAccessMode.Field);
#pragma warning restore CS8602 // Dereference of a possibly null reference.

            builder.HasMany(_ => _.Status);
        }
    }
}