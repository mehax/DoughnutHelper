using Microsoft.EntityFrameworkCore.Migrations;

namespace DoughnutHelper.Persistence.Migrations
{
    public partial class SeedMessagesTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "Id", "ByAnswer", "IsQuestion", "ParentId", "Title" },
                values: new object[] { 1, null, true, null, "Do I want a doughnut?" });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "Id", "ByAnswer", "IsQuestion", "ParentId", "Title" },
                values: new object[] { 2, 1, true, 1, "Do I deserve it?" });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "Id", "ByAnswer", "IsQuestion", "ParentId", "Title" },
                values: new object[] { 5, 0, true, 1, "Maybe you want an apple?" });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "Id", "ByAnswer", "IsQuestion", "ParentId", "Title" },
                values: new object[] { 3, 1, true, 2, "Are you sure?" });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "Id", "ByAnswer", "IsQuestion", "ParentId", "Title" },
                values: new object[] { 4, 0, true, 2, "Is it a good doughnut?" });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "Id", "ByAnswer", "IsQuestion", "ParentId", "Title" },
                values: new object[,]
                {
                    { 6, 1, false, 3, "Get it." },
                    { 7, 0, false, 3, "Do jumping jacks first." },
                    { 8, 1, false, 4, "What are you waiting for? Grab it now." },
                    { 9, 0, false, 4, "Wait 'till you find a sinful, unforgettable doughnut." }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
