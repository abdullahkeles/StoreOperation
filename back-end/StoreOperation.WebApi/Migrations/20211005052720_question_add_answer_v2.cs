using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace StoreOperation.WebApi.Migrations
{
    public partial class question_add_answer_v2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CheckListQuestionAnswers",
                columns: table => new
                {
                    CheckListQuestionAnswerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Answer = table.Column<bool>(type: "bit", nullable: false),
                    AnswerState = table.Column<byte>(type: "tinyint", nullable: false),
                    Skor = table.Column<byte>(type: "tinyint", nullable: false),
                    CheckListId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CheckListQuestionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CheckListQuestionAnswers", x => x.CheckListQuestionAnswerId);
                    table.ForeignKey(
                        name: "FK_CheckListQuestionAnswers_CheckListQuestions_CheckListQuestionId",
                        column: x => x.CheckListQuestionId,
                        principalTable: "CheckListQuestions",
                        principalColumn: "CheckListQuestionId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CheckListQuestionAnswers_CheckLists_CheckListId",
                        column: x => x.CheckListId,
                        principalTable: "CheckLists",
                        principalColumn: "CheckListId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CheckListQuestionAnswers_CheckListId",
                table: "CheckListQuestionAnswers",
                column: "CheckListId");

            migrationBuilder.CreateIndex(
                name: "IX_CheckListQuestionAnswers_CheckListQuestionId",
                table: "CheckListQuestionAnswers",
                column: "CheckListQuestionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CheckListQuestionAnswers");
        }
    }
}
