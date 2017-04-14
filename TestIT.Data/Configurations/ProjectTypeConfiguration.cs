using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TestIT.Entities;

namespace TestIT.Data.Configurations
{
    public class ProjectTypeConfiguration : EntityBaseConfiguration<ProjectType>
    {
        public new void Configure(EntityTypeBuilder<ProjectType> builder)
        {
            base.Configure(builder);
            builder.Property(u => u.Type).IsRequired().HasMaxLength(255);
            builder.Property(u => u.Type).IsRequired().HasMaxLength(255);
        }
    }
}