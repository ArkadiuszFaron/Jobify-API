using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Jobify.Domain.Migrations
{
    /// <inheritdoc />
    public partial class AddIndustryTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IndustryId",
                table: "Jobs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Industries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Code = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Industries", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Industries",
                columns: new[] { "Id", "Code", "CreatedAt", "ModifiedAt", "Name" },
                values: new object[,]
                {
                    { 1, "business", new DateTime(2024, 7, 22, 23, 31, 51, 350, DateTimeKind.Utc).AddTicks(6820), null, "Business Development" },
                    { 2, "copywriting", new DateTime(2024, 7, 22, 23, 31, 51, 350, DateTimeKind.Utc).AddTicks(6820), null, "Copywriting &amp; Content" },
                    { 3, "supporting", new DateTime(2024, 7, 22, 23, 31, 51, 350, DateTimeKind.Utc).AddTicks(6820), null, "Customer Success" },
                    { 4, "technical-support", new DateTime(2024, 7, 22, 23, 31, 51, 350, DateTimeKind.Utc).AddTicks(6820), null, "Technical Support" },
                    { 5, "data-science", new DateTime(2024, 7, 22, 23, 31, 51, 350, DateTimeKind.Utc).AddTicks(6820), null, "Data Science" },
                    { 6, "design-multimedia", new DateTime(2024, 7, 22, 23, 31, 51, 350, DateTimeKind.Utc).AddTicks(6820), null, "Design &amp; Creative" },
                    { 7, "web-app-design", new DateTime(2024, 7, 22, 23, 31, 51, 350, DateTimeKind.Utc).AddTicks(6820), null, "Web &amp; App Design" },
                    { 8, "admin", new DateTime(2024, 7, 22, 23, 31, 51, 350, DateTimeKind.Utc).AddTicks(6820), null, "DevOps &amp; SysAdmin" },
                    { 9, "engineering", new DateTime(2024, 7, 22, 23, 31, 51, 350, DateTimeKind.Utc).AddTicks(6820), null, "Software Engineering" },
                    { 10, "accounting-finance", new DateTime(2024, 7, 22, 23, 31, 51, 350, DateTimeKind.Utc).AddTicks(6830), null, "Finance &amp; Legal" },
                    { 11, "hr", new DateTime(2024, 7, 22, 23, 31, 51, 350, DateTimeKind.Utc).AddTicks(6830), null, "HR &amp; Recruiting" },
                    { 12, "marketing", new DateTime(2024, 7, 22, 23, 31, 51, 350, DateTimeKind.Utc).AddTicks(6830), null, "Sales" },
                    { 13, "seller", new DateTime(2024, 7, 22, 23, 31, 51, 350, DateTimeKind.Utc).AddTicks(6830), null, "Sales" },
                    { 14, "seo", new DateTime(2024, 7, 22, 23, 31, 51, 350, DateTimeKind.Utc).AddTicks(6830), null, "SEO" },
                    { 15, "smm", new DateTime(2024, 7, 22, 23, 31, 51, 350, DateTimeKind.Utc).AddTicks(6830), null, "Social Media Marketing" },
                    { 16, "management", new DateTime(2024, 7, 22, 23, 31, 51, 350, DateTimeKind.Utc).AddTicks(6830), null, "Product &amp; Operations" },
                    { 17, "dev", new DateTime(2024, 7, 22, 23, 31, 51, 350, DateTimeKind.Utc).AddTicks(6830), null, "Programming" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Jobs_IndustryId",
                table: "Jobs",
                column: "IndustryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Jobs_Industries_IndustryId",
                table: "Jobs",
                column: "IndustryId",
                principalTable: "Industries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Jobs_Industries_IndustryId",
                table: "Jobs");

            migrationBuilder.DropTable(
                name: "Industries");

            migrationBuilder.DropIndex(
                name: "IX_Jobs_IndustryId",
                table: "Jobs");

            migrationBuilder.DropColumn(
                name: "IndustryId",
                table: "Jobs");
        }
    }
}
