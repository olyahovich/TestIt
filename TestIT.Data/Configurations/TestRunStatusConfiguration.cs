using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TestIT.Entities;

namespace TestIT.Data.Configurations
{
    public class TestRunStatusConfiguration : EntityBaseConfiguration<TestRunStatus>
    {
        public TestRunStatusConfiguration(EntityTypeBuilder<TestRunStatus> builder)
        {

        }
    }
}