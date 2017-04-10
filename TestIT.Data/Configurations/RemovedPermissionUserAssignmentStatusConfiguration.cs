using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TestIT.Entities;

namespace TestIT.Data.Configurations
{
    public class RemovedPermissionUserAssignmentStatusConfiguration : EntityBaseConfiguration<RemovedPermissionUserAssignment>
    {
        public RemovedPermissionUserAssignmentStatusConfiguration(EntityTypeBuilder<RemovedPermissionUserAssignment> builder)
        {
            builder.Property(u => u.PermissionId).IsRequired();
            builder.Property(u => u.UserAssignmentId).IsRequired();
            builder.Property(u => u.CreatedBy).IsRequired();
            builder.Property(u => u.ModifiedBy).IsRequired();
            builder.Property(u => u.CreatedOn).IsRequired(); ;
            builder.Property(u => u.ModifiedOn).IsRequired(); ;
        }
    }
}