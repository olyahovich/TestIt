using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace TestIT.Web.Migrations
{
    public partial class Initial2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RemoteHosts_RemoteHostConfigurations_RemoteHostConfigurationId",
                table: "RemoteHosts");

            migrationBuilder.DropForeignKey(
                name: "FK_RemoteHosts_RemoteHostStatuses_RemoteHostStatusId",
                table: "RemoteHosts");

            migrationBuilder.DropForeignKey(
                name: "FK_TestRunPhases_TestRunResults_TestRunResultId",
                table: "TestRunPhases");

            migrationBuilder.DropTable(
                name: "TestDatas");

            migrationBuilder.DropIndex(
                name: "IX_TestRunPhases_TestRunResultId",
                table: "TestRunPhases");

            migrationBuilder.DropColumn(
                name: "TestResultId",
                table: "TestRunPhases");

            migrationBuilder.DropColumn(
                name: "TestRunResultId",
                table: "TestRunPhases");

            migrationBuilder.DropColumn(
                name: "ConfigurationId",
                table: "RemoteHosts");

            migrationBuilder.DropColumn(
                name: "StatusId",
                table: "RemoteHosts");

            migrationBuilder.AddColumn<string>(
                name: "UserAssignmentId",
                table: "RoleUserAssignments",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserAssignmentId1",
                table: "RoleUserAssignments",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "RemoteHostStatusId",
                table: "RemoteHosts",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "RemoteHostConfigurationId",
                table: "RemoteHosts",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_RoleUserAssignments_UserAssignmentId1",
                table: "RoleUserAssignments",
                column: "UserAssignmentId1");

            migrationBuilder.AddForeignKey(
                name: "FK_RemoteHosts_RemoteHostConfigurations_RemoteHostConfigurationId",
                table: "RemoteHosts",
                column: "RemoteHostConfigurationId",
                principalTable: "RemoteHostConfigurations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RemoteHosts_RemoteHostStatuses_RemoteHostStatusId",
                table: "RemoteHosts",
                column: "RemoteHostStatusId",
                principalTable: "RemoteHostStatuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RoleUserAssignments_UserAssignments_UserAssignmentId1",
                table: "RoleUserAssignments",
                column: "UserAssignmentId1",
                principalTable: "UserAssignments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RemoteHosts_RemoteHostConfigurations_RemoteHostConfigurationId",
                table: "RemoteHosts");

            migrationBuilder.DropForeignKey(
                name: "FK_RemoteHosts_RemoteHostStatuses_RemoteHostStatusId",
                table: "RemoteHosts");

            migrationBuilder.DropForeignKey(
                name: "FK_RoleUserAssignments_UserAssignments_UserAssignmentId1",
                table: "RoleUserAssignments");

            migrationBuilder.DropIndex(
                name: "IX_RoleUserAssignments_UserAssignmentId1",
                table: "RoleUserAssignments");

            migrationBuilder.DropColumn(
                name: "UserAssignmentId",
                table: "RoleUserAssignments");

            migrationBuilder.DropColumn(
                name: "UserAssignmentId1",
                table: "RoleUserAssignments");

            migrationBuilder.AddColumn<int>(
                name: "TestResultId",
                table: "TestRunPhases",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TestRunResultId",
                table: "TestRunPhases",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "RemoteHostStatusId",
                table: "RemoteHosts",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "RemoteHostConfigurationId",
                table: "RemoteHosts",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "ConfigurationId",
                table: "RemoteHosts",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "StatusId",
                table: "RemoteHosts",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "TestDatas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Currency = table.Column<decimal>(nullable: false),
                    EmailAddress = table.Column<string>(maxLength: 80, nullable: false),
                    Password = table.Column<string>(maxLength: 100, nullable: false),
                    Username = table.Column<string>(maxLength: 24, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestDatas", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TestRunPhases_TestRunResultId",
                table: "TestRunPhases",
                column: "TestRunResultId");

            migrationBuilder.AddForeignKey(
                name: "FK_RemoteHosts_RemoteHostConfigurations_RemoteHostConfigurationId",
                table: "RemoteHosts",
                column: "RemoteHostConfigurationId",
                principalTable: "RemoteHostConfigurations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RemoteHosts_RemoteHostStatuses_RemoteHostStatusId",
                table: "RemoteHosts",
                column: "RemoteHostStatusId",
                principalTable: "RemoteHostStatuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TestRunPhases_TestRunResults_TestRunResultId",
                table: "TestRunPhases",
                column: "TestRunResultId",
                principalTable: "TestRunResults",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
