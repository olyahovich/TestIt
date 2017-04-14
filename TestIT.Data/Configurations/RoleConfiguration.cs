using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TestIT.Entities;

namespace TestIT.Data.Configurations
{
    public class RoleConfiguration : EntityBaseConfiguration<Role>
    {
        public new void Configure(EntityTypeBuilder<Role> builder)
        {
            base.Configure(builder);
            builder.Property(u => u.ProjectTypeId).IsRequired();
            builder.Property(u => u.Title).IsRequired();
            builder.HasMany(u => u.Permissions).WithOne(r=> r.Role).HasForeignKey(r => r.RoleId);
        }
    }
}