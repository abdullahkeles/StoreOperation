using Microsoft.EntityFrameworkCore.Migrations;

namespace StoreOperation.WebApi.Migrations
{
    public partial class checkList_add_sort : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Sort",
                table: "CheckListQuestions",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Sort",
                table: "CheckListQuestionGroups",
                type: "int",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Sort",
                table: "CheckListQuestions");

            migrationBuilder.DropColumn(
                name: "Sort",
                table: "CheckListQuestionGroups");
        }
    }
}
