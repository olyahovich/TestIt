using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TestIT.Entities;

namespace TestIT.Data.Configurations
{
    public class ObjectConfiguration : EntityBaseConfiguration<Object>
    {
        public new void Configure(EntityTypeBuilder<Object> builder)
        {
            base.Configure(builder);
            builder.Property(u => u.Description).HasMaxLength(1000);
            builder.Property(u => u.Title).IsRequired().HasMaxLength(255);
        }
    }
}