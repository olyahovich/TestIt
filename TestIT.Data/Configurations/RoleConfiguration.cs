using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StaticDotNet.EntityFrameworkCore.ModelConfiguration;
using TestIT.Entities;

namespace TestIT.Data.Configurations
{
    public class RoleConfiguration : EntityTypeConfiguration<Role>
    {
        public override void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.Property(u => u.ProjectTypeId).IsRequired();
            builder.Property(u => u.Title).IsRequired();
            builder.HasMany(u => u.Permissions).WithOne(r=> r.Role).HasForeignKey(r => r.RoleId);
        }
    }
}