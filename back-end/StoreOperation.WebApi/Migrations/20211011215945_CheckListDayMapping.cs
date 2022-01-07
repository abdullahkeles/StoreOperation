using Microsoft.EntityFrameworkCore.Migrations;

namespace StoreOperation.WebApi.Migrations
{
    public partial class CheckListDayMapping : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_CheckListDays_StoreId_Day",
                table: "CheckListDays",
                columns: new[] { "StoreId", "Day" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_CheckListDays_StoreId_Day",
                table: "CheckListDays");
        }
    }
}
