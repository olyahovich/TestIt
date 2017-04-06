using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using TestIT.Entities;

namespace TestIT.Data
{
    public class TestITContext : IdentityDbContext<ApplicationUser>
    {
        public TestITContext(DbContextOptions<TestITContext> options) : base(options)
        {
        }

        public DbSet<Error> Errors { get; set; }
        public DbSet<File> Files { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<RemoteHost> RemoteHosts { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<RoleUserAssignment> UserRoles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var entity in modelBuilder.Model.GetEntityTypes())
            {
                entity.Relational().TableName = entity.DisplayName();
            }
        }
    }
}
