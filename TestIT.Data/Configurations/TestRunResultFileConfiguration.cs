using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TestIT.Entities;

namespace TestIT.Data.Configurations
{
    public class TestRunResultFileConfiguration : EntityBaseConfiguration<TestRunResultFile>
    {
        public new void Configure(EntityTypeBuilder<TestRunResultFile> builder)
        {
            base.Configure(builder);
            builder.Property(u => u.RemoteHostId).IsRequired();
            builder.Property(u => u.TestRunActionId).IsRequired();
            builder.Property(u => u.TestRunResultId).IsRequired();
            builder.Property(u => u.FileId).IsRequired();
            builder.Property(u => u.CreatedOn);
            builder.Property(u => u.ModifiedOn);
        }
    }
}