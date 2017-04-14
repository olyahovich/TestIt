using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TestIT.Entities;

namespace TestIT.Data.Configurations
{
    public class ProjectConfiguration : EntityBaseConfiguration<Project>
    {
        public new void Configure(EntityTypeBuilder<Project> builder)
        {
            base.Configure(builder);
            builder.Property(u => u.ProjectTypeId).IsRequired();
            builder.Property(u => u.ProjectStatusId).IsRequired();
            builder.Property(u => u.Description).IsRequired().HasMaxLength(1000);
            builder.Property(u => u.Title).IsRequired().HasMaxLength(255);
            builder.Property(u => u.CreatedBy).IsRequired();
            builder.Property(u => u.ModifiedBy).IsRequired();
            builder.HasMany(u => u.TestRuns).WithOne(r => r.Project).HasForeignKey(r => r.ProjectId);
            builder.HasMany(u => u.UserAssignments).WithOne(r => r.Project).HasForeignKey(r => r.ProjectId);
            builder.Property(u => u.CompletedOn);
            builder.Property(u => u.CompletedBy);
            builder.Property(u => u.CreatedBy).IsRequired();
            builder.Property(u => u.ModifiedBy).IsRequired();
            builder.Property(u => u.CreatedOn);
            builder.Property(u => u.ModifiedOn);
        }
    }
}
