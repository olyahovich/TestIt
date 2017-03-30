using TestIT.Models;
using TestIT.ViewModels;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace TestIT.Data
{
    public class TestITContext : IdentityDbContext<ApplicationUser>
    {
        public TestITContext(DbContextOptions<TestITContext> options) : base(options)
        {
        }

        public DbSet<TestData> TestData { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TestData>().ToTable("TestData");
            base.OnModelCreating(modelBuilder);
        }
    }
}
