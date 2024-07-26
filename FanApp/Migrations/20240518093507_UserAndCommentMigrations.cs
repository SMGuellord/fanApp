using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FanApp.Migrations
{
    /// <inheritdoc />
    public partial class UserAndCommentMigrations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Fistname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Lastname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DOB = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Commentary = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comments_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedBy", "CreatedOn", "DOB", "Fistname", "Lastname", "ModifiedBy", "ModifiedOn" },
                values: new object[,]
                {
                    { new Guid("1c2c4ab1-f386-40b5-a07f-5a74517ea8a1"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 5, 18, 11, 35, 7, 225, DateTimeKind.Local).AddTicks(7192), new DateTime(2024, 5, 18, 11, 35, 7, 225, DateTimeKind.Local).AddTicks(7192), "Gleah", "Muhiya", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 5, 18, 11, 35, 7, 225, DateTimeKind.Local).AddTicks(7193) },
                    { new Guid("c400f7db-2037-4678-b85b-365bd5b85a17"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 5, 18, 11, 35, 7, 225, DateTimeKind.Local).AddTicks(7172), new DateTime(2024, 5, 18, 11, 35, 7, 225, DateTimeKind.Local).AddTicks(7096), "Guellord", "Muhiya", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 5, 18, 11, 35, 7, 225, DateTimeKind.Local).AddTicks(7173) },
                    { new Guid("d5964359-22f8-4494-9b23-b1ee373febdb"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 5, 18, 11, 35, 7, 225, DateTimeKind.Local).AddTicks(7177), new DateTime(2024, 5, 18, 11, 35, 7, 225, DateTimeKind.Local).AddTicks(7176), "Leah", "Muhiya", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 5, 18, 11, 35, 7, 225, DateTimeKind.Local).AddTicks(7177) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Comments_UserId",
                table: "Comments",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
