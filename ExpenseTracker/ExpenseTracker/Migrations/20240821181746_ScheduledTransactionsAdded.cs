using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExpenseTracker.Migrations
{
    public partial class ScheduledTransactionsAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ScheduledExpenses",
                columns: table => new
                {
                    ScheduledExpenseId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ScheduledExpenseName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ScheduledExpenseDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ScheduledExpenseAmount = table.Column<double>(type: "float", nullable: false),
                    ScheduledExpenseDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ApplicationUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ExpenseGroupId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScheduledExpenses", x => x.ScheduledExpenseId);
                });

            migrationBuilder.CreateTable(
                name: "ScheduledIncomes",
                columns: table => new
                {
                    ScheduledIncomeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ScheduledIncomeName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ScheduledIncomeDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ScheduledIncomeAmount = table.Column<double>(type: "float", nullable: false),
                    ScheduledIncomeDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsRecurring = table.Column<bool>(type: "bit", nullable: true),
                    ApplicationUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IncomeGroupId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScheduledIncomes", x => x.ScheduledIncomeId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ScheduledExpenses");

            migrationBuilder.DropTable(
                name: "ScheduledIncomes");
        }
    }
}
