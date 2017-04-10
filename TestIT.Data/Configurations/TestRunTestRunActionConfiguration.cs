using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TestIT.Entities;

namespace TestIT.Data.Configurations
{
    public class TestRunTestRunActionConfiguration : EntityBaseConfiguration<TestRunTestRunAction>
    {
        public TestRunTestRunActionConfiguration(EntityTypeBuilder<TestRunTestRunAction> builder)
        {
            builder.Property(u => u.TestRunActionId).IsRequired();
        }
    }
}