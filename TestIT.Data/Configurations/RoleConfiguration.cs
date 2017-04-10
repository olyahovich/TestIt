using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TestIT.Entities;

namespace TestIT.Data.Configurations
{
    public class RoleConfiguration : EntityBaseConfiguration<Role>
    {
        public RoleConfiguration(EntityTypeBuilder<Role> builder)
        {
            builder.Property(u => u.ProjectTypeId).IsRequired();
            builder.Property(u => u.Title).IsRequired();
            builder.HasMany(u => u.Permissions).WithOne(r=> r.Role).HasForeignKey(r => r.RoleId);
        }
    }
}