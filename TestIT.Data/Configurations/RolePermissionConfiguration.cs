using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TestIT.Entities;

namespace TestIT.Data.Configurations
{
    public class RolePermissionConfiguration : EntityBaseConfiguration<RolePermission>
    {
        public new void Configure(EntityTypeBuilder<RolePermission> builder)
        {
            base.Configure(builder);
            builder.Property(u => u.PermissionId).IsRequired();
            builder.Property(u => u.RoleId).IsRequired();
            builder.Property(u => u.CreatedBy).IsRequired();
            builder.Property(u => u.ModifiedBy).IsRequired();
            builder.Property(u => u.CreatedOn);
            builder.Property(u => u.ModifiedOn);
        }
    }
}