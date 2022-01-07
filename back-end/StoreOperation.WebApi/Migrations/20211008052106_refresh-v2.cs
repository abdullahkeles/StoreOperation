using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace StoreOperation.WebApi.Migrations
{
    public partial class refreshv2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "CheckListId",
                table: "CheckListQuestions",
                type: "uniqueidentifier",
                nullable: true);

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
                onDelete: ReferentialAction.Restrict);
        }
    }
}
