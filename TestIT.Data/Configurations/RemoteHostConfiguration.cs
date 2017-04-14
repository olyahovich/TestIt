using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TestIT.Entities;

namespace TestIT.Data.Configurations
{
    public class RemoteHostConfiguration : EntityBaseConfiguration<RemoteHost>
    {
        public new void Configure(EntityTypeBuilder<RemoteHost> builder)
        {
            base.Configure(builder);
            builder.Property(u => u.StatusId).IsRequired();
            builder.Property(u => u.HostName).IsRequired().HasMaxLength(255);
            builder.Property(u => u.ConfigurationId).IsRequired();
            builder.Property(u => u.CreatedBy).IsRequired();
            builder.Property(u => u.ModifiedBy).IsRequired();
            builder.Property(u => u.CreatedOn);
            builder.Property(u => u.ModifiedOn);
        }
    }
}
