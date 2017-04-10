using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TestIT.Entities;

namespace TestIT.Data.Configurations
{
    public class TestRunPhaseConfiguration : EntityBaseConfiguration<TestRunPhase>
    {
        public TestRunPhaseConfiguration(EntityTypeBuilder<TestRunPhase> builder)
        {

        }
    }
}