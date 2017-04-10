using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TestIT.Entities;

namespace TestIT.Data.Configurations
{
    public class FileConfiguration : EntityBaseConfiguration<File>
    {
        public FileConfiguration(EntityTypeBuilder<File> builder)
        {

        }
    }
}
