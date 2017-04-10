using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TestIT.Entities;

namespace TestIT.Data.Configurations
{
    public class RemovedPermissionUserAssignmentStatusConfiguration : EntityBaseConfiguration<RemovedPermissionUserAssignment>
    {
        public RemovedPermissionUserAssignmentStatusConfiguration(EntityTypeBuilder<RemovedPermissionUserAssignment> builder)
        {

        }
    }
}