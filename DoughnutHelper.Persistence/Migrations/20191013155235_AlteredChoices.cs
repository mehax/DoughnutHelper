using Microsoft.EntityFrameworkCore.Migrations;

namespace DoughnutHelper.Persistence.Migrations
{
    public partial class AlteredChoices : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Choices_Messages_QuestionId",
                table: "Choices");

            migrationBuilder.DropIndex(
                name: "IX_Choices_QuestionId",
                table: "Choices");

            migrationBuilder.DropColumn(
                name: "QuestionId",
                table: "Choices");

            migrationBuilder.CreateIndex(
                name: "IX_Choices_QuestionMessageId",
                table: "Choices",
                column: "QuestionMessageId");

            migrationBuilder.AddForeignKey(
                name: "FK_Choices_Messages_QuestionMessageId",
                table: "Choices",
                column: "QuestionMessageId",
                principalTable: "Messages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Choices_Messages_QuestionMessageId",
                table: "Choices");

            migrationBuilder.DropIndex(
                name: "IX_Choices_QuestionMessageId",
                table: "Choices");

            migrationBuilder.AddColumn<int>(
                name: "QuestionId",
                table: "Choices",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Choices_QuestionId",
                table: "Choices",
                column: "QuestionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Choices_Messages_QuestionId",
                table: "Choices",
                column: "QuestionId",
                principalTable: "Messages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
