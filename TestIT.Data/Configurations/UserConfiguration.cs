using System;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StaticDotNet.EntityFrameworkCore.ModelConfiguration;
using TestIT.Entities;

namespace TestIT.Data.Configurations
{
    public class UserConfiguration: EntityTypeConfiguration<User>
    {
        public override void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(u => u.FirstName).IsRequired().HasMaxLength(255);
            builder.Property(u => u.LastName).IsRequired().HasMaxLength(255);
            builder.Property(u => u.Email).IsRequired().HasMaxLength(254);
            builder.Property(u => u.PasswordHash).IsRequired().HasMaxLength(255);
            builder.Property(u => u.IsLocked).IsRequired();
            builder.Property(u => u.CreatedOn);
            builder.Property(u => u.CreatedBy);
        }
    }
}
