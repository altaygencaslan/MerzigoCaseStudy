using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UserAPI.Business.Migrations
{
    /// <inheritdoc />
    public partial class FirstContentMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    FirstName = table.Column<string>(type: "text", nullable: false),
                    LastName = table.Column<string>(type: "text", nullable: false),
                    TotalContents = table.Column<int>(type: "integer", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedUserId = table.Column<Guid>(type: "uuid", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedUserId = table.Column<Guid>(type: "uuid", nullable: true),
                    IsDeletable = table.Column<bool>(type: "boolean", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedDate", "CreatedUserId", "FirstName", "IsDeletable", "IsDeleted", "LastName", "TotalContents", "UpdatedDate", "UpdatedUserId" },
                values: new object[] { new Guid("1fd23216-5e38-454c-a84a-c3601bb225d5"), new DateTime(2024, 10, 12, 12, 14, 25, 714, DateTimeKind.Local).AddTicks(5234), new Guid("00000000-0000-0000-0000-000000000000"), "admin", false, false, "admin", 0, new DateTime(2024, 10, 12, 12, 14, 25, 714, DateTimeKind.Local).AddTicks(5244), new Guid("00000000-0000-0000-0000-000000000000") });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
