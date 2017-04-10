using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TestIT.Entities;

namespace TestIT.Data.Configurations
{
    public class ActionConfiguration : EntityBaseConfiguration<Action>
    {
        public ActionConfiguration(EntityTypeBuilder<Action> builder)
        {
            builder.Property(u => u.Title).IsRequired().HasMaxLength(255);
            builder.Property(u => u.Description).HasMaxLength(1000);
        }
    }
}