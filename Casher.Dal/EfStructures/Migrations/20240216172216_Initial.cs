using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Casher.Dal.EfStructures.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.CreateTable(
                name: "bank_accounts",
                schema: "dbo",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    card_number = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: false),
                    pin_code = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: false),
                    account_balance = table.Column<double>(type: "float", nullable: false),
                    is_blocked = table.Column<bool>(type: "bit", nullable: false),
                    time_stamp = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_bank_accounts", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "operation_types",
                schema: "dbo",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    time_stamp = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_operation_types", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "pin_code_attempts",
                schema: "dbo",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    bank_account_id = table.Column<int>(type: "int", nullable: false),
                    attempt_date_time = table.Column<DateTime>(type: "datetime2", nullable: false),
                    is_successful = table.Column<bool>(type: "bit", nullable: false),
                    time_stamp = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pin_code_attempts", x => x.id);
                    table.ForeignKey(
                        name: "FK_pin_code_attempts_bank_accounts",
                        column: x => x.bank_account_id,
                        principalSchema: "dbo",
                        principalTable: "bank_accounts",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "operations",
                schema: "dbo",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    bank_account_id = table.Column<int>(type: "int", nullable: false),
                    operation_type_id = table.Column<int>(type: "int", nullable: false),
                    operation_date_time = table.Column<DateTime>(type: "datetime2", nullable: false),
                    money_amount = table.Column<double>(type: "float", nullable: true),
                    time_stamp = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_operations", x => x.id);
                    table.ForeignKey(
                        name: "FK_operations_bank_accounts",
                        column: x => x.bank_account_id,
                        principalSchema: "dbo",
                        principalTable: "bank_accounts",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_operations_operation_types",
                        column: x => x.operation_type_id,
                        principalSchema: "dbo",
                        principalTable: "operation_types",
                        principalColumn: "id");
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "bank_accounts",
                columns: new[] { "id", "account_balance", "card_number", "is_blocked", "pin_code" },
                values: new object[,]
                {
                    { 1, 250.0, "1111111111111111", false, "1111" },
                    { 2, 0.0, "2222222222222222", false, "2222" },
                    { 3, 1000.0, "3333333333333333", true, "3333" }
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "operation_types",
                columns: new[] { "id", "name" },
                values: new object[,]
                {
                    { 1, "Balance" },
                    { 2, "Withdraw Cash" }
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "operations",
                columns: new[] { "id", "bank_account_id", "money_amount", "operation_date_time", "operation_type_id" },
                values: new object[,]
                {
                    { 1, 1, null, new DateTime(2024, 1, 30, 12, 30, 27, 0, DateTimeKind.Utc), 1 },
                    { 2, 2, null, new DateTime(2024, 2, 5, 16, 15, 43, 0, DateTimeKind.Utc), 1 },
                    { 3, 2, 800.0, new DateTime(2024, 2, 5, 16, 17, 58, 0, DateTimeKind.Utc), 2 },
                    { 4, 3, 2000.0, new DateTime(2024, 1, 16, 4, 45, 31, 0, DateTimeKind.Utc), 2 },
                    { 5, 3, null, new DateTime(2024, 1, 16, 4, 49, 3, 0, DateTimeKind.Utc), 1 }
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "pin_code_attempts",
                columns: new[] { "id", "attempt_date_time", "bank_account_id", "is_successful" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 1, 30, 12, 29, 9, 0, DateTimeKind.Utc), 1, true },
                    { 2, new DateTime(2024, 2, 5, 16, 13, 52, 0, DateTimeKind.Utc), 2, false },
                    { 3, new DateTime(2024, 2, 5, 16, 14, 59, 0, DateTimeKind.Utc), 2, true },
                    { 4, new DateTime(2024, 1, 16, 4, 43, 19, 0, DateTimeKind.Utc), 3, true },
                    { 5, new DateTime(2024, 2, 14, 18, 19, 23, 0, DateTimeKind.Utc), 3, false },
                    { 6, new DateTime(2024, 2, 14, 18, 20, 49, 0, DateTimeKind.Utc), 3, false },
                    { 7, new DateTime(2024, 2, 14, 18, 21, 13, 0, DateTimeKind.Utc), 3, false },
                    { 8, new DateTime(2024, 2, 14, 18, 22, 56, 0, DateTimeKind.Utc), 3, false }
                });

            migrationBuilder.CreateIndex(
                name: "IX_card_number",
                schema: "dbo",
                table: "bank_accounts",
                column: "card_number",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_operations_bank_account_id",
                schema: "dbo",
                table: "operations",
                column: "bank_account_id");

            migrationBuilder.CreateIndex(
                name: "IX_operations_operation_type_id",
                schema: "dbo",
                table: "operations",
                column: "operation_type_id");

            migrationBuilder.CreateIndex(
                name: "IX_pin_code_attempts_bank_account_id",
                schema: "dbo",
                table: "pin_code_attempts",
                column: "bank_account_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "operations",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "pin_code_attempts",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "operation_types",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "bank_accounts",
                schema: "dbo");
        }
    }
}
