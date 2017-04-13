using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using TestIT.Data.Configurations;
using TestIT.Entities;
using RemoteHostConfiguration = TestIT.Entities.RemoteHostConfiguration;

namespace TestIT.Data
{
    public class TestITContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Action> Actions { get; set; }
        public DbSet<Error> Errors { get; set; }
        public DbSet<File> Files { get; set; }
        public DbSet<FileType> FileTypes { get; set; }
        public DbSet<Object> Objects { get; set; }
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<ProjectStatus> ProjectStatuses { get; set; }
        public DbSet<ProjectType> ProjectTypes { get; set; }
        public DbSet<RemoteHost> RemoteHosts { get; set; }
        public DbSet<RemoteHostConfiguration> RemoteHostConfigurations { get; set; }
        public DbSet<RemoteHostStatus> RemoteHostStatuses { get; set; }
        public DbSet<RemovedPermissionUserAssignment> RemovedPermissionUserAssignments { get; set; }
        public new DbSet<Role> Roles { get; set; }
        public DbSet<RolePermission> RolePermissions { get; set; }
        public DbSet<RoleUserAssignment> RoleUserAssignments { get; set; }
        public DbSet<TestRun> TestRuns { get; set; }
        public DbSet<TestRunAction> TestRunActions { get; set; }
        public DbSet<TestRunFile> TestRunFiles { get; set; }
        public DbSet<TestRunPhase> TestRunPhases { get; set; }
        public DbSet<TestRunRemoteHost> TestRunRemoteHosts { get; set; }
        public DbSet<TestRunResult> TestRunResults { get; set; }
        public DbSet<TestRunResultFile> TestRunResultFiles { get; set; }
        public DbSet<TestRunStatus> TestRunStatuses { get; set; }
        public DbSet<TestRunTestRunAction> TestRunTestRunActions { get; set; }
        public new DbSet<User> Users { get; set; }
        public DbSet<UserAssignment> UserAssignments { get; set; }
        public DbSet<TestData> TestDatas { get; set; }
        public TestITContext(DbContextOptions<TestITContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ActionConfiguration());
            base.OnModelCreating(modelBuilder);
        }
    }
}
