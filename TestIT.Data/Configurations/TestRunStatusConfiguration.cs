using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TestIT.Entities;

namespace TestIT.Data.Configurations
{
    public class TestRunStatusConfiguration : EntityBaseConfiguration<TestRunStatus>
    {
        public new void Configure(EntityTypeBuilder<TestRunStatus> builder)
        {
            base.Configure(builder);
            builder.Property(u => u.Status).IsRequired().HasMaxLength(255);
        }
    }
}