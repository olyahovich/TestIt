using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TestIT.Entities;

namespace TestIT.Data.Configurations
{
    public class TestRunFileConfiguration : EntityBaseConfiguration<TestRunFile>
    {
        public TestRunFileConfiguration(EntityTypeBuilder<TestRunFile> builder)
        {

        }
    }
}