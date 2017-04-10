using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TestIT.Entities;

namespace TestIT.Data.Configurations
{
    public class ProjectConfiguration : EntityBaseConfiguration<Project>
    {
        public ProjectConfiguration(EntityTypeBuilder<Project> builder)
        {

        }
    }
}
