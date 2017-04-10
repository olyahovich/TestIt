using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TestIT.Entities;

namespace TestIT.Data.Configurations
{
    public class TestRunConfiguration : EntityBaseConfiguration<TestRun>
    {
        public TestRunConfiguration(EntityTypeBuilder<TestRun> builder)
        {

        }
    }
}