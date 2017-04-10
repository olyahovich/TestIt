using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TestIT.Entities;

namespace TestIT.Data.Configurations
{
    public class ObjectConfiguration : EntityBaseConfiguration<Object>
    {
        public ObjectConfiguration(EntityTypeBuilder<Object> builder)
        {
            builder.Property(u => u.Description).HasMaxLength(1000);
            builder.Property(u => u.Title).IsRequired().HasMaxLength(255);
        }
    }
}