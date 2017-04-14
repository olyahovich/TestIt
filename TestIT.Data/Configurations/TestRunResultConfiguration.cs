using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TestIT.Entities;

namespace TestIT.Data.Configurations
{
    public class TestRunResultConfiguration : EntityBaseConfiguration<TestRunResult>
    {
        public new void Configure(EntityTypeBuilder<TestRunResult> builder)
        {
            base.Configure(builder);
            builder.Property(u => u.Result).IsRequired().HasMaxLength(255);
        }
    }
}