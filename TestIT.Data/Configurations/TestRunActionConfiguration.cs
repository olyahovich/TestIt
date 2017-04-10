using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TestIT.Entities;

namespace TestIT.Data.Configurations
{
    public class TestRunActionConfiguration : EntityBaseConfiguration<TestRunAction>
    {
        public TestRunActionConfiguration(EntityTypeBuilder<TestRunAction> builder)
        {

        }
    }
}