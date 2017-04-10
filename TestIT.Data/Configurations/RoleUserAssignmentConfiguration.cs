using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TestIT.Entities;

namespace TestIT.Data.Configurations
{
    public class RoleUserAssignmentConfiguration : EntityBaseConfiguration<RoleUserAssignment>
    {
        public RoleUserAssignmentConfiguration(EntityTypeBuilder<RoleUserAssignment> builder)
        {
            builder.Property(u => u.RoleId).IsRequired();
            builder.Property(u => u.UserId).IsRequired();
            builder.Property(u => u.CreatedBy).IsRequired();
            builder.Property(u => u.ModifiedBy).IsRequired();
            builder.Property(u => u.CreatedOn);
            builder.Property(u => u.ModifiedOn);
        }
    }
}