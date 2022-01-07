using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace StoreOperation.WebApi.Migrations
{
    public partial class question_add_answer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CheckListQuestions_CheckLists_CheckListId",
                table: "CheckListQuestions");

            migrationBuilder.DropColumn(
                name: "Answer",
                table: "CheckListQuestions");

            migrationBuilder.DropColumn(
                name: "AnswerState",
                table: "CheckListQuestions");

            migrationBuilder.AlterColumn<Guid>(
                name: "CheckListId",
                table: "CheckListQuestions",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddForeignKey(
                name: "FK_CheckListQuestions_CheckLists_CheckListId",
                table: "CheckListQuestions",
                column: "CheckListId",
                principalTable: "CheckLists",
                principalColumn: "CheckListId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CheckListQuestions_CheckLists_CheckListId",
                table: "CheckListQuestions");

            migrationBuilder.AlterColumn<Guid>(
                name: "CheckListId",
                table: "CheckListQuestions",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Answer",
                table: "CheckListQuestions",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<byte>(
                name: "AnswerState",
                table: "CheckListQuestions",
                type: "tinyint",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.AddForeignKey(
                name: "FK_CheckListQuestions_CheckLists_CheckListId",
                table: "CheckListQuestions",
                column: "CheckListId",
                principalTable: "CheckLists",
                principalColumn: "CheckListId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
