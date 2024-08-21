using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExpenseTracker.Migrations
{
    public partial class ScheduledFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "IsRecurring",
                table: "ScheduledIncomes",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ApplicationUserId",
                table: "ScheduledIncomes",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ApplicationUserId",
                table: "ScheduledExpenses",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsRecurring",
                table: "ScheduledExpenses",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateIndex(
                name: "IX_ScheduledIncomes_ApplicationUserId",
                table: "ScheduledIncomes",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ScheduledExpenses_ApplicationUserId",
                table: "ScheduledExpenses",
                column: "ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_ScheduledExpenses_AspNetUsers_ApplicationUserId",
                table: "ScheduledExpenses",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ScheduledIncomes_AspNetUsers_ApplicationUserId",
                table: "ScheduledIncomes",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ScheduledExpenses_AspNetUsers_ApplicationUserId",
                table: "ScheduledExpenses");

            migrationBuilder.DropForeignKey(
                name: "FK_ScheduledIncomes_AspNetUsers_ApplicationUserId",
                table: "ScheduledIncomes");

            migrationBuilder.DropIndex(
                name: "IX_ScheduledIncomes_ApplicationUserId",
                table: "ScheduledIncomes");

            migrationBuilder.DropIndex(
                name: "IX_ScheduledExpenses_ApplicationUserId",
                table: "ScheduledExpenses");

            migrationBuilder.DropColumn(
                name: "IsRecurring",
                table: "ScheduledExpenses");

            migrationBuilder.AlterColumn<bool>(
                name: "IsRecurring",
                table: "ScheduledIncomes",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<string>(
                name: "ApplicationUserId",
                table: "ScheduledIncomes",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ApplicationUserId",
                table: "ScheduledExpenses",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);
        }
    }
}
