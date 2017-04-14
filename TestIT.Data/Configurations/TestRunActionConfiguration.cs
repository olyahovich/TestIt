using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TestIT.Entities;

namespace TestIT.Data.Configurations
{
    public class TestRunActionConfiguration : EntityBaseConfiguration<TestRunAction>
    {
        public new void Configure(EntityTypeBuilder<TestRunAction> builder)
        {
            base.Configure(builder);
            builder.Property(u => u.Action).IsRequired().HasMaxLength(255);
        }
    }
}