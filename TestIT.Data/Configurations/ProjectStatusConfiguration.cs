using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TestIT.Entities;

namespace TestIT.Data.Configurations
{
    public class ProjectStatusConfiguration : EntityBaseConfiguration<ProjectStatus>
    {
        public ProjectStatusConfiguration(EntityTypeBuilder<ProjectStatus> builder)
        {

        }
    }
}