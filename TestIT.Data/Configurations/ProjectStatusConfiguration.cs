using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TestIT.Entities;

namespace TestIT.Data.Configurations
{
    public class ProjectStatusConfiguration : EntityBaseConfiguration<ProjectStatus>
    {
        public new void Configure(EntityTypeBuilder<ProjectStatus> builder)
        {
            base.Configure(builder);
            builder.Property(u => u.Status).IsRequired().HasMaxLength(255);
        }
    }
}