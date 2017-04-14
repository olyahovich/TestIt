using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TestIT.Data.Configurations
{
    public class RemoteHostConfigurationConfiguration : EntityBaseConfiguration<Entities.RemoteHostConfiguration>
    {
        public new void Configure(EntityTypeBuilder<Entities.RemoteHostConfiguration> builder)
        {
            base.Configure(builder);
            builder.Property(u => u.OperationSystem).IsRequired().HasMaxLength(255);
            builder.Property(u => u.PasswordHash).IsRequired().HasMaxLength(255); 
            builder.Property(u => u.PasswordSalt).IsRequired().HasMaxLength(255); 
            builder.Property(u => u.Port).IsRequired();
            builder.Property(u => u.Ipv4).IsRequired().HasMaxLength(21);
            builder.Property(u => u.Ipv6).IsRequired().HasMaxLength(45);
            builder.Property(u => u.HostName).IsRequired().HasMaxLength(255);
            builder.Property(u => u.UserName).IsRequired().HasMaxLength(255); 
            builder.Property(u => u.CreatedBy).IsRequired();
            builder.Property(u => u.ModifiedBy).IsRequired();
            builder.Property(u => u.CreatedOn);
            builder.Property(u => u.ModifiedOn);
        }
    }
}