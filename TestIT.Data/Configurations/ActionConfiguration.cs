using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TestIT.Entities;

namespace TestIT.Data.Configurations
{
    public class ActionConfiguration : EntityBaseConfiguration<Action>
    {
        public new void Configure(EntityTypeBuilder<Action> builder)
        {
            base.Configure(builder);
            builder.Property(u => u.Title).IsRequired().HasMaxLength(255);
            builder.Property(u => u.Description).HasMaxLength(1000);
        }
    }
}