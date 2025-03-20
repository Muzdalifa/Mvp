using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Mvp.Api.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "mvp");

            migrationBuilder.CreateTable(
                name: "Companies",
                schema: "mvp",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Website = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Departments",
                schema: "mvp",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Location = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    CompanyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Departments_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalSchema: "mvp",
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                schema: "mvp",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    HireDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Position = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    ManagerId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CompanyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Employees_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalSchema: "mvp",
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Employees_Employees_ManagerId",
                        column: x => x.ManagerId,
                        principalSchema: "mvp",
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeDepartments",
                schema: "mvp",
                columns: table => new
                {
                    EmployeeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DepartmentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsManager = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeDepartments", x => new { x.EmployeeId, x.DepartmentId });
                    table.ForeignKey(
                        name: "FK_EmployeeDepartments_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalSchema: "mvp",
                        principalTable: "Departments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmployeeDepartments_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalSchema: "mvp",
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                schema: "mvp",
                table: "Companies",
                columns: new[] { "Id", "Address", "Description", "IsActive", "Name", "Website" },
                values: new object[,]
                {
                    { new Guid("18e795b5-c9da-4cbe-a3ed-9b50232791cb"), "456 Test Street", "Test company.", false, "Test", "https://test.com" },
                    { new Guid("4c0fda5f-15bb-4bfa-b354-6fdf243520d5"), "123 Company Street", "A leading company.", false, "Company", "https://company.com" }
                });

            migrationBuilder.InsertData(
                schema: "mvp",
                table: "Departments",
                columns: new[] { "Id", "CompanyId", "Description", "Location", "Name" },
                values: new object[,]
                {
                    { new Guid("8f2d33f9-d06a-45ce-872b-c4ddf384eabf"), new Guid("4c0fda5f-15bb-4bfa-b354-6fdf243520d5"), null, "Building B", "Marketing Department" },
                    { new Guid("c2a761be-c44d-4cf3-b7c4-32ee80d036ca"), new Guid("4c0fda5f-15bb-4bfa-b354-6fdf243520d5"), null, "Building C", "Finance Department" },
                    { new Guid("cfcea384-82f0-4072-921f-4fa56aca0321"), new Guid("4c0fda5f-15bb-4bfa-b354-6fdf243520d5"), null, "Building A", "IT Department" },
                    { new Guid("d1a761be-c44d-4cf3-b7c4-32ee80d036ca"), new Guid("18e795b5-c9da-4cbe-a3ed-9b50232791cb"), null, "Building D", "Research Department" }
                });

            migrationBuilder.InsertData(
                schema: "mvp",
                table: "Employees",
                columns: new[] { "Id", "CompanyId", "Email", "FirstName", "HireDate", "LastName", "ManagerId", "PhoneNumber", "Position" },
                values: new object[,]
                {
                    { new Guid("715714ec-a50e-45ff-8e07-ce5a6df80674"), new Guid("18e795b5-c9da-4cbe-a3ed-9b50232791cb"), "alice.green@test.com", "Alice", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Green", null, "555-2001", "Research Scientist" },
                    { new Guid("dd26e6f2-7d28-4dbd-a82e-c165ed480971"), new Guid("4c0fda5f-15bb-4bfa-b354-6fdf243520d5"), "gary.smith@company.com", "Gary", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Smith", null, "555-1001", "Chief Executive Officer" },
                    { new Guid("062cf920-2fca-4f83-afb3-e133c7ff5ff5"), new Guid("4c0fda5f-15bb-4bfa-b354-6fdf243520d5"), "mary.johnson@company.com", "Mary", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Johnson", new Guid("dd26e6f2-7d28-4dbd-a82e-c165ed480971"), "555-1002", "IT Manager" },
                    { new Guid("19891195-af38-4d7b-afc9-ca5ec7aefc7a"), new Guid("4c0fda5f-15bb-4bfa-b354-6fdf243520d5"), "jane.brown@company.com", "Jane", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Brown", new Guid("dd26e6f2-7d28-4dbd-a82e-c165ed480971"), "555-1004", "Financial Analyst" },
                    { new Guid("b370958b-7b9b-4688-a8c9-db0b1cd61298"), new Guid("4c0fda5f-15bb-4bfa-b354-6fdf243520d5"), "john.williams@company.com", "John", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Williams", new Guid("dd26e6f2-7d28-4dbd-a82e-c165ed480971"), "555-1003", "Marketing Specialist" }
                });

            migrationBuilder.InsertData(
                schema: "mvp",
                table: "EmployeeDepartments",
                columns: new[] { "DepartmentId", "EmployeeId", "IsManager" },
                values: new object[,]
                {
                    { new Guid("cfcea384-82f0-4072-921f-4fa56aca0321"), new Guid("062cf920-2fca-4f83-afb3-e133c7ff5ff5"), true },
                    { new Guid("8f2d33f9-d06a-45ce-872b-c4ddf384eabf"), new Guid("19891195-af38-4d7b-afc9-ca5ec7aefc7a"), false },
                    { new Guid("c2a761be-c44d-4cf3-b7c4-32ee80d036ca"), new Guid("19891195-af38-4d7b-afc9-ca5ec7aefc7a"), false },
                    { new Guid("8f2d33f9-d06a-45ce-872b-c4ddf384eabf"), new Guid("b370958b-7b9b-4688-a8c9-db0b1cd61298"), false },
                    { new Guid("cfcea384-82f0-4072-921f-4fa56aca0321"), new Guid("b370958b-7b9b-4688-a8c9-db0b1cd61298"), false }
                });

            migrationBuilder.InsertData(
                schema: "mvp",
                table: "Employees",
                columns: new[] { "Id", "CompanyId", "Email", "FirstName", "HireDate", "LastName", "ManagerId", "PhoneNumber", "Position" },
                values: new object[,]
                {
                    { new Guid("5ca3b0c3-62a2-484a-8d7a-7547feb3d05c"), new Guid("4c0fda5f-15bb-4bfa-b354-6fdf243520d5"), "sarah.miller@company.com", "Sarah", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Miller", new Guid("062cf920-2fca-4f83-afb3-e133c7ff5ff5"), "555-1006", "System Analyst" },
                    { new Guid("642d23a7-62ac-49cb-bdbc-b74dab2d0a06"), new Guid("4c0fda5f-15bb-4bfa-b354-6fdf243520d5"), "robert.chen@company.com", "Robert", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Chen", new Guid("062cf920-2fca-4f83-afb3-e133c7ff5ff5"), "555-1005", "Software Developer" }
                });

            migrationBuilder.InsertData(
                schema: "mvp",
                table: "EmployeeDepartments",
                columns: new[] { "DepartmentId", "EmployeeId", "IsManager" },
                values: new object[,]
                {
                    { new Guid("cfcea384-82f0-4072-921f-4fa56aca0321"), new Guid("5ca3b0c3-62a2-484a-8d7a-7547feb3d05c"), false },
                    { new Guid("cfcea384-82f0-4072-921f-4fa56aca0321"), new Guid("642d23a7-62ac-49cb-bdbc-b74dab2d0a06"), false }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Departments_CompanyId",
                schema: "mvp",
                table: "Departments",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeDepartments_DepartmentId",
                schema: "mvp",
                table: "EmployeeDepartments",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_CompanyId",
                schema: "mvp",
                table: "Employees",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_ManagerId",
                schema: "mvp",
                table: "Employees",
                column: "ManagerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmployeeDepartments",
                schema: "mvp");

            migrationBuilder.DropTable(
                name: "Departments",
                schema: "mvp");

            migrationBuilder.DropTable(
                name: "Employees",
                schema: "mvp");

            migrationBuilder.DropTable(
                name: "Companies",
                schema: "mvp");
        }
    }
}
