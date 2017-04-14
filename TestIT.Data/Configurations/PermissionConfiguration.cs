using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TestIT.Entities;

namespace TestIT.Data.Configurations
{
    public class PermissionConfiguration : EntityBaseConfiguration<Permission>
    {
        public new void Configure(EntityTypeBuilder<Permission> builder)
        {
            base.Configure(builder);
            builder.Property(u => u.ActionId).IsRequired();
            builder.Property(u => u.ObjectId).IsRequired();
        }
    }
}