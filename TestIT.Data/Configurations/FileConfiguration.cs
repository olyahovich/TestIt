using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TestIT.Entities;

namespace TestIT.Data.Configurations
{
    public class FileConfiguration : EntityBaseConfiguration<File>
    {
        public new void Configure(EntityTypeBuilder<File> builder)
        {
            base.Configure(builder);
            builder.Property(u => u.FileTypeId).IsRequired();
            builder.Property(u => u.Uri).HasMaxLength(2000).IsUnicode();
            builder.Property(u => u.NetworkPath).IsRequired().HasMaxLength(1000);
            builder.Property(u => u.Title).IsRequired().HasMaxLength(255);
            builder.Property(u => u.UserId).IsRequired();
            builder.Property(u => u.ModifiedBy).IsRequired();
            builder.Property(u => u.CreatedOn);
            builder.Property(u => u.ModifiedOn);
        }
    }
}
