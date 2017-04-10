using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TestIT.Entities;

namespace TestIT.Data.Configurations
{
    public class TestRunResultFileConfiguration : EntityBaseConfiguration<TestRunResultFile>
    {
        public TestRunResultFileConfiguration(EntityTypeBuilder<TestRunResultFile> builder)
        {

        }
    }
}