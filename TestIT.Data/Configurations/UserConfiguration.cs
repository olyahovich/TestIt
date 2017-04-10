using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using TestIT.Entities;

namespace TestIT.Data.Configurations
{
    public class UserConfiguration:EntityBaseConfiguration<User>
    {
        public UserConfiguration(EntityTypeBuilder<User> builder)
        {
            builder.Property(u => u.Username).IsRequired().HasMaxLength(255);
            builder.Property(u => u.FirstName).IsRequired().HasMaxLength(255);
            builder.Property(u => u.LastName).IsRequired().HasMaxLength(255);
            builder.Property(u => u.Email).IsRequired().HasMaxLength(254);
            builder.Property(u => u.PasswordHash).IsRequired().HasMaxLength(255);
            builder.Property(u => u.PasswordSalt).IsRequired().HasMaxLength(255);
            builder.Property(u => u.IsLocked).IsRequired();
            builder.Property(u => u.CreatedOn);
            builder.Property(u => u.CreatedBy);
        }
    }
}
