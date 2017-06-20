﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using TestIT.Data;

namespace TestIT.Web.Migrations
{
    [DbContext(typeof(TestItContext))]
    [Migration("20170619001638_Phase3")]
    partial class Phase3
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.2")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Discriminator")
                        .IsRequired();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex");

                    b.ToTable("AspNetRoles");

                    b.HasDiscriminator<string>("Discriminator").HasValue("IdentityRole");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("OpenIddict.Models.OpenIddictApplication", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClientId");

                    b.Property<string>("ClientSecret");

                    b.Property<string>("DisplayName");

                    b.Property<string>("LogoutRedirectUri");

                    b.Property<string>("RedirectUri");

                    b.Property<string>("Type");

                    b.HasKey("Id");

                    b.HasIndex("ClientId")
                        .IsUnique();

                    b.ToTable("OpenIddictApplications");
                });

            modelBuilder.Entity("OpenIddict.Models.OpenIddictAuthorization", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ApplicationId");

                    b.Property<string>("Scope");

                    b.Property<string>("Subject");

                    b.HasKey("Id");

                    b.HasIndex("ApplicationId");

                    b.ToTable("OpenIddictAuthorizations");
                });

            modelBuilder.Entity("OpenIddict.Models.OpenIddictScope", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.HasKey("Id");

                    b.ToTable("OpenIddictScopes");
                });

            modelBuilder.Entity("OpenIddict.Models.OpenIddictToken", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ApplicationId");

                    b.Property<string>("AuthorizationId");

                    b.Property<string>("Subject");

                    b.Property<string>("Type");

                    b.HasKey("Id");

                    b.HasIndex("ApplicationId");

                    b.HasIndex("AuthorizationId");

                    b.ToTable("OpenIddictTokens");
                });

            modelBuilder.Entity("TestIT.Entities.Action", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<string>("Title");

                    b.HasKey("Id");

                    b.ToTable("Actions");
                });

            modelBuilder.Entity("TestIT.Entities.Error", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DateCreated");

                    b.Property<string>("Message");

                    b.Property<string>("StackTrace");

                    b.HasKey("Id");

                    b.ToTable("Errors");
                });

            modelBuilder.Entity("TestIT.Entities.File", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedOn");

                    b.Property<int>("FileTypeId");

                    b.Property<string>("ModifiedBy");

                    b.Property<DateTime>("ModifiedOn");

                    b.Property<string>("NetworkPath");

                    b.Property<string>("Title");

                    b.Property<string>("Uri");

                    b.Property<string>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("FileTypeId");

                    b.HasIndex("UserId");

                    b.ToTable("Files");
                });

            modelBuilder.Entity("TestIT.Entities.FileType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Type");

                    b.HasKey("Id");

                    b.ToTable("FileTypes");
                });

            modelBuilder.Entity("TestIT.Entities.Object", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<string>("Title");

                    b.HasKey("Id");

                    b.ToTable("Objects");
                });

            modelBuilder.Entity("TestIT.Entities.Permission", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ActionId");

                    b.Property<int>("ObjectId");

                    b.HasKey("Id");

                    b.HasIndex("ActionId");

                    b.HasIndex("ObjectId");

                    b.ToTable("Permissions");
                });

            modelBuilder.Entity("TestIT.Entities.Project", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CompletedBy");

                    b.Property<DateTime>("CompletedOn");

                    b.Property<DateTime>("CreatedOn");

                    b.Property<string>("Description");

                    b.Property<string>("ModifiedBy");

                    b.Property<DateTime>("ModifiedOn");

                    b.Property<int>("ProjectStatusId");

                    b.Property<int>("ProjectTypeId");

                    b.Property<string>("Title");

                    b.Property<string>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("ProjectStatusId");

                    b.HasIndex("ProjectTypeId");

                    b.HasIndex("UserId");

                    b.ToTable("Projects");
                });

            modelBuilder.Entity("TestIT.Entities.ProjectStatus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Status");

                    b.HasKey("Id");

                    b.ToTable("ProjectStatuses");
                });

            modelBuilder.Entity("TestIT.Entities.ProjectType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Type");

                    b.HasKey("Id");

                    b.ToTable("ProjectTypes");
                });

            modelBuilder.Entity("TestIT.Entities.RemoteHost", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedOn");

                    b.Property<string>("HostName");

                    b.Property<string>("ModifiedBy");

                    b.Property<DateTime>("ModifiedOn");

                    b.Property<int>("RemoteHostConfigurationId");

                    b.Property<int>("RemoteHostStatusId");

                    b.Property<string>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("RemoteHostConfigurationId");

                    b.HasIndex("RemoteHostStatusId");

                    b.HasIndex("UserId");

                    b.ToTable("RemoteHosts");
                });

            modelBuilder.Entity("TestIT.Entities.RemoteHostConfiguration", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedOn");

                    b.Property<string>("HostName");

                    b.Property<string>("Ipv4");

                    b.Property<string>("Ipv6");

                    b.Property<string>("ModifiedBy");

                    b.Property<DateTime>("ModifiedOn");

                    b.Property<string>("OperationSystem");

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PasswordSalt");

                    b.Property<int>("Port");

                    b.Property<string>("UserId");

                    b.Property<string>("UserName");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("RemoteHostConfigurations");
                });

            modelBuilder.Entity("TestIT.Entities.RemoteHostStatus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Status");

                    b.HasKey("Id");

                    b.ToTable("RemoteHostStatuses");
                });

            modelBuilder.Entity("TestIT.Entities.RemovedPermissionUserAssignment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedOn");

                    b.Property<string>("ModifiedBy");

                    b.Property<DateTime>("ModifiedOn");

                    b.Property<int>("PermissionId");

                    b.Property<int>("UserAssignmentId");

                    b.Property<string>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("PermissionId");

                    b.HasIndex("UserAssignmentId");

                    b.HasIndex("UserId");

                    b.ToTable("RemovedPermissionUserAssignments");
                });

            modelBuilder.Entity("TestIT.Entities.RolePermission", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedOn");

                    b.Property<string>("ModifiedBy");

                    b.Property<DateTime>("ModifiedOn");

                    b.Property<int>("PermissionId");

                    b.Property<string>("RoleId");

                    b.Property<string>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("PermissionId");

                    b.HasIndex("RoleId");

                    b.HasIndex("UserId");

                    b.ToTable("RolePermissions");
                });

            modelBuilder.Entity("TestIT.Entities.RoleUserAssignment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CreatedBy");

                    b.Property<DateTime>("CreatedOn");

                    b.Property<string>("ModifiedBy");

                    b.Property<DateTime>("ModifiedOn");

                    b.Property<string>("RoleId");

                    b.Property<string>("UserAssignmentId");

                    b.Property<int?>("UserAssignmentId1");

                    b.Property<string>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.HasIndex("UserAssignmentId1");

                    b.HasIndex("UserId");

                    b.ToTable("RoleUserAssignments");
                });

            modelBuilder.Entity("TestIT.Entities.TestRun", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AssignedTo");

                    b.Property<string>("CompletedBy");

                    b.Property<DateTime>("CompletedOn");

                    b.Property<DateTime>("CreatedOn");

                    b.Property<string>("Description");

                    b.Property<string>("ModifiedBy");

                    b.Property<DateTime>("ModifiedOn");

                    b.Property<int>("ProjectId");

                    b.Property<int>("TestRunResultId");

                    b.Property<int>("TestRunStatusId");

                    b.Property<string>("Title");

                    b.Property<string>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("ProjectId");

                    b.HasIndex("TestRunResultId");

                    b.HasIndex("TestRunStatusId");

                    b.HasIndex("UserId");

                    b.ToTable("TestRuns");
                });

            modelBuilder.Entity("TestIT.Entities.TestRunAction", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Action");

                    b.HasKey("Id");

                    b.ToTable("TestRunActions");
                });

            modelBuilder.Entity("TestIT.Entities.TestRunFile", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("FileId");

                    b.Property<int>("TestRunId");

                    b.HasKey("Id");

                    b.HasIndex("FileId");

                    b.HasIndex("TestRunId");

                    b.ToTable("TestRunFiles");
                });

            modelBuilder.Entity("TestIT.Entities.TestRunPhase", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Phase");

                    b.Property<int>("TestRunId");

                    b.HasKey("Id");

                    b.HasIndex("TestRunId");

                    b.ToTable("TestRunPhases");
                });

            modelBuilder.Entity("TestIT.Entities.TestRunRemoteHost", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("RemoteHostId");

                    b.Property<int>("TestRunId");

                    b.HasKey("Id");

                    b.HasIndex("RemoteHostId");

                    b.HasIndex("TestRunId");

                    b.ToTable("TestRunRemoteHosts");
                });

            modelBuilder.Entity("TestIT.Entities.TestRunResult", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Result");

                    b.HasKey("Id");

                    b.ToTable("TestRunResults");
                });

            modelBuilder.Entity("TestIT.Entities.TestRunResultFile", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedOn");

                    b.Property<int>("FileId");

                    b.Property<DateTime>("ModifiedOn");

                    b.Property<int>("RemoteHostId");

                    b.Property<int>("TestRunActionId");

                    b.Property<int>("TestRunResultId");

                    b.HasKey("Id");

                    b.HasIndex("FileId");

                    b.HasIndex("RemoteHostId");

                    b.HasIndex("TestRunActionId");

                    b.HasIndex("TestRunResultId");

                    b.ToTable("TestRunResultFiles");
                });

            modelBuilder.Entity("TestIT.Entities.TestRunStatus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Status");

                    b.HasKey("Id");

                    b.ToTable("TestRunStatuses");
                });

            modelBuilder.Entity("TestIT.Entities.TestRunTestRunAction", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("TestRunActionId");

                    b.Property<int>("TestRunId");

                    b.HasKey("Id");

                    b.HasIndex("TestRunActionId");

                    b.HasIndex("TestRunId");

                    b.ToTable("TestRunTestRunActions");
                });

            modelBuilder.Entity("TestIT.Entities.User", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("CreatedBy");

                    b.Property<DateTime>("CreatedOn");

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<string>("FirstName");

                    b.Property<string>("FullName");

                    b.Property<bool>("IsLocked");

                    b.Property<string>("LastName");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("ModifiedBy");

                    b.Property<DateTime>("ModifiedOn");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("TestIT.Entities.UserAssignment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CreatedBy");

                    b.Property<DateTime>("CreatedOn");

                    b.Property<string>("ModifiedBy");

                    b.Property<DateTime>("ModifiedOn");

                    b.Property<int>("ProjectId");

                    b.Property<string>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("ProjectId");

                    b.HasIndex("UserId");

                    b.ToTable("UserAssignments");
                });

            modelBuilder.Entity("TestIT.Entities.Role", b =>
                {
                    b.HasBaseType("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole");

                    b.Property<int>("ProjectTypeId");

                    b.Property<string>("Title");

                    b.HasIndex("ProjectTypeId");

                    b.ToTable("Role");

                    b.HasDiscriminator().HasValue("Role");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole")
                        .WithMany("Claims")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("TestIT.Entities.User")
                        .WithMany("Claims")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("TestIT.Entities.User")
                        .WithMany("Logins")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("TestIT.Entities.User")
                        .WithMany("Roles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("OpenIddict.Models.OpenIddictAuthorization", b =>
                {
                    b.HasOne("OpenIddict.Models.OpenIddictApplication", "Application")
                        .WithMany("Authorizations")
                        .HasForeignKey("ApplicationId");
                });

            modelBuilder.Entity("OpenIddict.Models.OpenIddictToken", b =>
                {
                    b.HasOne("OpenIddict.Models.OpenIddictApplication", "Application")
                        .WithMany("Tokens")
                        .HasForeignKey("ApplicationId");

                    b.HasOne("OpenIddict.Models.OpenIddictAuthorization", "Authorization")
                        .WithMany("Tokens")
                        .HasForeignKey("AuthorizationId");
                });

            modelBuilder.Entity("TestIT.Entities.File", b =>
                {
                    b.HasOne("TestIT.Entities.FileType", "FileType")
                        .WithMany()
                        .HasForeignKey("FileTypeId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("TestIT.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("TestIT.Entities.Permission", b =>
                {
                    b.HasOne("TestIT.Entities.Action", "Action")
                        .WithMany()
                        .HasForeignKey("ActionId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("TestIT.Entities.Object", "Object")
                        .WithMany()
                        .HasForeignKey("ObjectId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("TestIT.Entities.Project", b =>
                {
                    b.HasOne("TestIT.Entities.ProjectStatus", "ProjectStatus")
                        .WithMany()
                        .HasForeignKey("ProjectStatusId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("TestIT.Entities.ProjectType", "ProjectType")
                        .WithMany()
                        .HasForeignKey("ProjectTypeId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("TestIT.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("TestIT.Entities.RemoteHost", b =>
                {
                    b.HasOne("TestIT.Entities.RemoteHostConfiguration", "RemoteHostConfiguration")
                        .WithMany()
                        .HasForeignKey("RemoteHostConfigurationId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("TestIT.Entities.RemoteHostStatus", "RemoteHostStatus")
                        .WithMany()
                        .HasForeignKey("RemoteHostStatusId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("TestIT.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("TestIT.Entities.RemoteHostConfiguration", b =>
                {
                    b.HasOne("TestIT.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("TestIT.Entities.RemovedPermissionUserAssignment", b =>
                {
                    b.HasOne("TestIT.Entities.Permission", "Permission")
                        .WithMany()
                        .HasForeignKey("PermissionId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("TestIT.Entities.UserAssignment", "UserAssignment")
                        .WithMany()
                        .HasForeignKey("UserAssignmentId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("TestIT.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("TestIT.Entities.RolePermission", b =>
                {
                    b.HasOne("TestIT.Entities.Permission", "Permission")
                        .WithMany()
                        .HasForeignKey("PermissionId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("TestIT.Entities.Role", "Role")
                        .WithMany("Permissions")
                        .HasForeignKey("RoleId");

                    b.HasOne("TestIT.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("TestIT.Entities.RoleUserAssignment", b =>
                {
                    b.HasOne("TestIT.Entities.Role", "Role")
                        .WithMany()
                        .HasForeignKey("RoleId");

                    b.HasOne("TestIT.Entities.UserAssignment", "UserAssignment")
                        .WithMany()
                        .HasForeignKey("UserAssignmentId1");

                    b.HasOne("TestIT.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("TestIT.Entities.TestRun", b =>
                {
                    b.HasOne("TestIT.Entities.Project", "Project")
                        .WithMany("TestRuns")
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("TestIT.Entities.TestRunResult", "TestRunResult")
                        .WithMany()
                        .HasForeignKey("TestRunResultId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("TestIT.Entities.TestRunStatus", "TestRunStatus")
                        .WithMany()
                        .HasForeignKey("TestRunStatusId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("TestIT.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("TestIT.Entities.TestRunFile", b =>
                {
                    b.HasOne("TestIT.Entities.File", "File")
                        .WithMany()
                        .HasForeignKey("FileId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("TestIT.Entities.TestRun", "TestRun")
                        .WithMany()
                        .HasForeignKey("TestRunId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("TestIT.Entities.TestRunPhase", b =>
                {
                    b.HasOne("TestIT.Entities.TestRun", "TestRun")
                        .WithMany()
                        .HasForeignKey("TestRunId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("TestIT.Entities.TestRunRemoteHost", b =>
                {
                    b.HasOne("TestIT.Entities.RemoteHost", "RemoteHost")
                        .WithMany()
                        .HasForeignKey("RemoteHostId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("TestIT.Entities.TestRun", "TestRun")
                        .WithMany("TestRunRemoteHosts")
                        .HasForeignKey("TestRunId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("TestIT.Entities.TestRunResultFile", b =>
                {
                    b.HasOne("TestIT.Entities.File", "File")
                        .WithMany()
                        .HasForeignKey("FileId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("TestIT.Entities.RemoteHost", "RemoteHost")
                        .WithMany()
                        .HasForeignKey("RemoteHostId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("TestIT.Entities.TestRunAction", "TestRunAction")
                        .WithMany()
                        .HasForeignKey("TestRunActionId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("TestIT.Entities.TestRunResult", "TestRunResult")
                        .WithMany()
                        .HasForeignKey("TestRunResultId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("TestIT.Entities.TestRunTestRunAction", b =>
                {
                    b.HasOne("TestIT.Entities.TestRunAction", "TestRunAction")
                        .WithMany()
                        .HasForeignKey("TestRunActionId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("TestIT.Entities.TestRun", "TestRun")
                        .WithMany("TestRunActions")
                        .HasForeignKey("TestRunId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("TestIT.Entities.UserAssignment", b =>
                {
                    b.HasOne("TestIT.Entities.Project", "Project")
                        .WithMany("UserAssignments")
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("TestIT.Entities.User", "User")
                        .WithMany("UserAssignments")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("TestIT.Entities.Role", b =>
                {
                    b.HasOne("TestIT.Entities.ProjectType", "ProjectType")
                        .WithMany()
                        .HasForeignKey("ProjectTypeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
