using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace StoreOperation.WebApi.Migrations
{
    public partial class checkList_Realiton_Update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CheckListQuestionGroups_CheckLists_CheckListId",
                table: "CheckListQuestionGroups");

            migrationBuilder.DropIndex(
                name: "IX_CheckListQuestionGroups_CheckListId",
                table: "CheckListQuestionGroups");

            migrationBuilder.DropColumn(
                name: "CheckListId",
                table: "CheckListQuestionGroups");

            migrationBuilder.AddColumn<Guid>(
                name: "CheckListId",
                table: "CheckListQuestions",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_CheckListQuestions_CheckListId",
                table: "CheckListQuestions",
                column: "CheckListId");

            migrationBuilder.AddForeignKey(
                name: "FK_CheckListQuestions_CheckLists_CheckListId",
                table: "CheckListQuestions",
                column: "CheckListId",
                principalTable: "CheckLists",
                principalColumn: "CheckListId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CheckListQuestions_CheckLists_CheckListId",
                table: "CheckListQuestions");

            migrationBuilder.DropIndex(
                name: "IX_CheckListQuestions_CheckListId",
                table: "CheckListQuestions");

            migrationBuilder.DropColumn(
                name: "CheckListId",
                table: "CheckListQuestions");

            migrationBuilder.AddColumn<Guid>(
                name: "CheckListId",
                table: "CheckListQuestionGroups",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CheckListQuestionGroups_CheckListId",
                table: "CheckListQuestionGroups",
                column: "CheckListId");

            migrationBuilder.AddForeignKey(
                name: "FK_CheckListQuestionGroups_CheckLists_CheckListId",
                table: "CheckListQuestionGroups",
                column: "CheckListId",
                principalTable: "CheckLists",
                principalColumn: "CheckListId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
