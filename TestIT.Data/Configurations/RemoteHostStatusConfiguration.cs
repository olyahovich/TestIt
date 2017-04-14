using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TestIT.Entities;

namespace TestIT.Data.Configurations
{
    public class RemoteHostStatusConfiguration : EntityBaseConfiguration<RemoteHostStatus>
    {
        public new void Configure(EntityTypeBuilder<RemoteHostStatus> builder)
        {
            base.Configure(builder);
            builder.Property(u => u.Status).IsRequired().HasMaxLength(255);
        }
    }
}