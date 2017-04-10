using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TestIT.Entities;

namespace TestIT.Data.Configurations
{
    public class FileTypeConfiguration : EntityBaseConfiguration<FileType>
    {
        public FileTypeConfiguration(EntityTypeBuilder<FileType> builder)
        {

        }
    }
}