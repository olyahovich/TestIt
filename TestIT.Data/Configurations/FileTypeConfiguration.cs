using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TestIT.Entities;

namespace TestIT.Data.Configurations
{
    public class FileTypeConfiguration : EntityBaseConfiguration<FileType>
    {
        public new void Configure(EntityTypeBuilder<FileType> builder)
        {
            base.Configure(builder);
            builder.Property(u => u.Type).IsRequired().HasMaxLength(255);
        }
    }
}