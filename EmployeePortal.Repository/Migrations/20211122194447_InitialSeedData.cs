using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EmployeePortal.Repository.Migrations
{
    public partial class InitialSeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    CreateDateTime = table.Column<DateTime>(type: "TEXT", nullable: true),
                    ModifiedDateTime = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    EmployeeJobType = table.Column<int>(type: "INTEGER", nullable: false),
                    Desription = table.Column<string>(type: "TEXT", nullable: true),
                    CreateDateTime = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    JobDescription = table.Column<string>(type: "TEXT", nullable: true),
                    EmployeeNumber = table.Column<string>(type: "TEXT", nullable: true),
                    HourlyPay = table.Column<decimal>(type: "TEXT", nullable: false),
                    Bonus = table.Column<decimal>(type: "TEXT", nullable: false),
                    DepartmentId = table.Column<Guid>(type: "TEXT", nullable: false),
                    EmployeeTypeId = table.Column<int>(type: "INTEGER", nullable: false),
                    CreateDateTime = table.Column<DateTime>(type: "TEXT", nullable: true),
                    ModifiedDateTime = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Employees_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Employees_EmployeeTypes_EmployeeTypeId",
                        column: x => x.EmployeeTypeId,
                        principalTable: "EmployeeTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "CreateDateTime", "ModifiedDateTime", "Name" },
                values: new object[] { new Guid("f5203daa-13b8-4022-90d8-8f946bbf2b24"), new DateTime(2021, 11, 22, 19, 44, 46, 469, DateTimeKind.Utc).AddTicks(3357), null, "HR" });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "CreateDateTime", "ModifiedDateTime", "Name" },
                values: new object[] { new Guid("d9224471-0a51-4ac0-9138-0d130b5379f0"), new DateTime(2021, 11, 22, 19, 44, 46, 469, DateTimeKind.Utc).AddTicks(3372), null, "IT" });

            migrationBuilder.InsertData(
                table: "EmployeeTypes",
                columns: new[] { "Id", "CreateDateTime", "Desription", "EmployeeJobType" },
                values: new object[] { 1, new DateTime(2021, 11, 22, 19, 44, 46, 469, DateTimeKind.Utc).AddTicks(8818), "Permanent", 1 });

            migrationBuilder.InsertData(
                table: "EmployeeTypes",
                columns: new[] { "Id", "CreateDateTime", "Desription", "EmployeeJobType" },
                values: new object[] { 2, new DateTime(2021, 11, 22, 19, 44, 46, 469, DateTimeKind.Utc).AddTicks(9279), "Contract", 2 });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Bonus", "CreateDateTime", "DepartmentId", "EmployeeNumber", "EmployeeTypeId", "HourlyPay", "JobDescription", "ModifiedDateTime", "Name" },
                values: new object[] { new Guid("05a4c183-267f-46d6-a140-09ccc05317ab"), 10m, new DateTime(2021, 11, 22, 19, 44, 46, 467, DateTimeKind.Utc).AddTicks(6453), new Guid("f5203daa-13b8-4022-90d8-8f946bbf2b24"), "A1001", 1, 8m, "Manager", null, "John" });

            migrationBuilder.CreateIndex(
                name: "IX_Employees_DepartmentId",
                table: "Employees",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_EmployeeTypeId",
                table: "Employees",
                column: "EmployeeTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Departments");

            migrationBuilder.DropTable(
                name: "EmployeeTypes");
        }
    }
}
