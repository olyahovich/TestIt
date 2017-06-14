using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TestIT.Entities;

namespace TestIT.Data.Configurations
{
    public class TestRunPhaseConfiguration : EntityBaseConfiguration<TestRunPhase>
    {
        public new void Configure(EntityTypeBuilder<TestRunPhase> builder)
        {
            base.Configure(builder);
            builder.Property(u => u.TestRunId).IsRequired();
            builder.Property(u => u.Phase).IsRequired().HasMaxLength(255);
        }
    }
}
