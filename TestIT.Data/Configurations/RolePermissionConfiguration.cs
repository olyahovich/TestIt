using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TestIT.Entities;

namespace TestIT.Data.Configurations
{
    public class RolePermissionConfiguration : EntityBaseConfiguration<RolePermission>
    {
        public RolePermissionConfiguration(EntityTypeBuilder<RolePermission> builder)
        {

        }
    }
}