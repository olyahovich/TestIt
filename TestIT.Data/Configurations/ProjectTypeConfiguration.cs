using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TestIT.Entities;

namespace TestIT.Data.Configurations
{
    public class ProjectTypeConfiguration : EntityBaseConfiguration<ProjectType>
    {
        public ProjectTypeConfiguration(EntityTypeBuilder<ProjectType> builder)
        {

        }
    }
}