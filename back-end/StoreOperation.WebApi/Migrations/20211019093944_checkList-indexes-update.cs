using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace StoreOperation.WebApi.Migrations
{
    public partial class checkListindexesupdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_CheckListDays_StoreId",
                table: "CheckListDays");

            migrationBuilder.DropIndex(
                name: "IX_CheckListDays_StoreId_Day",
                table: "CheckListDays");

            migrationBuilder.DropIndex(
                name: "IX_AppUsers_Email",
                table: "AppUsers");

            migrationBuilder.DropIndex(
                name: "IX_AppUsers_UserName",
                table: "AppUsers");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Day",
                table: "CheckListDays",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.CreateIndex(
                name: "IX_CheckListDays_StoreId",
                table: "CheckListDays",
                column: "StoreId")
                .Annotation("SqlServer:FillFactor", 80);

            migrationBuilder.CreateIndex(
                name: "IX_CheckListDays_StoreId_Day",
                table: "CheckListDays",
                columns: new[] { "StoreId", "Day" })
                .Annotation("SqlServer:FillFactor", 80);

            migrationBuilder.CreateIndex(
                name: "IX_AppUsers_Email",
                table: "AppUsers",
                column: "Email",
                unique: true)
                .Annotation("SqlServer:FillFactor", 80);

            migrationBuilder.CreateIndex(
                name: "IX_AppUsers_UserId",
                table: "AppUsers",
                column: "UserId")
                .Annotation("SqlServer:FillFactor", 80);

            migrationBuilder.CreateIndex(
                name: "IX_AppUsers_UserName",
                table: "AppUsers",
                column: "UserName",
                unique: true)
                .Annotation("SqlServer:FillFactor", 80);

            migrationBuilder.CreateIndex(
                name: "IX_AppStores_StoreId",
                table: "AppStores",
                column: "StoreId")
                .Annotation("SqlServer:FillFactor", 80);

            migrationBuilder.CreateIndex(
                name: "IX_AppRoles_RoleId",
                table: "AppRoles",
                column: "RoleId")
                .Annotation("SqlServer:FillFactor", 80);

            migrationBuilder.CreateIndex(
                name: "IX_AppLogs_Id",
                table: "AppLogs",
                column: "Id")
                .Annotation("SqlServer:FillFactor", 80);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_CheckListDays_StoreId",
                table: "CheckListDays");

            migrationBuilder.DropIndex(
                name: "IX_CheckListDays_StoreId_Day",
                table: "CheckListDays");

            migrationBuilder.DropIndex(
                name: "IX_AppUsers_Email",
                table: "AppUsers");

            migrationBuilder.DropIndex(
                name: "IX_AppUsers_UserId",
                table: "AppUsers");

            migrationBuilder.DropIndex(
                name: "IX_AppUsers_UserName",
                table: "AppUsers");

            migrationBuilder.DropIndex(
                name: "IX_AppStores_StoreId",
                table: "AppStores");

            migrationBuilder.DropIndex(
                name: "IX_AppRoles_RoleId",
                table: "AppRoles");

            migrationBuilder.DropIndex(
                name: "IX_AppLogs_Id",
                table: "AppLogs");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Day",
                table: "CheckListDays",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "date");

            migrationBuilder.CreateIndex(
                name: "IX_CheckListDays_StoreId",
                table: "CheckListDays",
                column: "StoreId");

            migrationBuilder.CreateIndex(
                name: "IX_CheckListDays_StoreId_Day",
                table: "CheckListDays",
                columns: new[] { "StoreId", "Day" });

            migrationBuilder.CreateIndex(
                name: "IX_AppUsers_Email",
                table: "AppUsers",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AppUsers_UserName",
                table: "AppUsers",
                column: "UserName",
                unique: true);
        }
    }
}
