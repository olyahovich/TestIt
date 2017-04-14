using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TestIT.Entities;

namespace TestIT.Data.Configurations
{
    public class TestRunConfiguration : EntityBaseConfiguration<TestRun>
    {
        public new void Configure(EntityTypeBuilder<TestRun> builder)
        {
            base.Configure(builder);
            builder.Property(u => u.ProjectId).IsRequired();
            builder.Property(u => u.AssignedTo).IsRequired();
            builder.Property(u => u.Description).HasMaxLength(1000);
            builder.Property(u => u.CompletedBy);
            builder.HasMany(s => s.TestRunRemoteHosts).WithOne(r => r.TestRun).HasForeignKey(r => r.TestRunId);
            builder.HasMany(s => s.TestRunActions).WithOne(r => r.TestRun).HasForeignKey(r => r.TestRunId);
            builder.Property(u => u.TestRunResultId).IsRequired();
            builder.Property(u => u.TestRunStatusId).IsRequired();
            builder.Property(u => u.Title).IsRequired().HasMaxLength(255);
            builder.Property(u => u.CompletedOn);
            builder.Property(u => u.CreatedBy).IsRequired();
            builder.Property(u => u.ModifiedBy).IsRequired();
            builder.Property(u => u.CreatedOn);
            builder.Property(u => u.ModifiedOn);
        }
    }
}