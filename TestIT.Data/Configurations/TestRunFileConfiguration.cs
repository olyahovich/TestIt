using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TestIT.Entities;

namespace TestIT.Data.Configurations
{
    public class TestRunFileConfiguration : EntityBaseConfiguration<TestRunFile>
    {
        public TestRunFileConfiguration(EntityTypeBuilder<TestRunFile> builder)
        {
            builder.Property(u => u.TestRunId).IsRequired();
            builder.Property(u => u.FileId).IsRequired();
        }
    }
}