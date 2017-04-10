using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TestIT.Entities;

namespace TestIT.Data.Configurations
{
    public class PermissionConfiguration : EntityBaseConfiguration<Permission>
    {
        public PermissionConfiguration(EntityTypeBuilder<Permission> builder)
        {

        }
    }
}