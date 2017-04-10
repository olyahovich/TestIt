using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TestIT.Entities;

namespace TestIT.Data.Configurations
{
    public class RoleUserAssignmentConfiguration : EntityBaseConfiguration<RoleUserAssignment>
    {
        public RoleUserAssignmentConfiguration(EntityTypeBuilder<RoleUserAssignment> builder)
        {

        }
    }
}