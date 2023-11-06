using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApp.Migrations
{
    /// <inheritdoc />
    public partial class DecimalBalance : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "Update_DateTime_UTC",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 10, 20, 16, 30, 5, 681, DateTimeKind.Utc).AddTicks(6610),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 10, 19, 22, 10, 18, 729, DateTimeKind.Utc).AddTicks(629));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Server_DateTime",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 10, 20, 19, 30, 5, 681, DateTimeKind.Local).AddTicks(5975),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 10, 20, 1, 10, 18, 729, DateTimeKind.Local).AddTicks(25));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateTime_UTC",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 10, 20, 16, 30, 5, 681, DateTimeKind.Utc).AddTicks(6295),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 10, 19, 22, 10, 18, 729, DateTimeKind.Utc).AddTicks(365));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Update_DateTime_UTC",
                table: "Accounts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 10, 20, 16, 30, 5, 681, DateTimeKind.Utc).AddTicks(4746),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 10, 19, 22, 10, 18, 728, DateTimeKind.Utc).AddTicks(8917));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Server_DateTime",
                table: "Accounts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 10, 20, 19, 30, 5, 681, DateTimeKind.Local).AddTicks(4009),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 10, 20, 1, 10, 18, 728, DateTimeKind.Local).AddTicks(8214));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateTime_UTC",
                table: "Accounts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 10, 20, 16, 30, 5, 681, DateTimeKind.Utc).AddTicks(4458),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 10, 19, 22, 10, 18, 728, DateTimeKind.Utc).AddTicks(8606));

            migrationBuilder.AlterColumn<decimal>(
                name: "Balance",
                table: "Accounts",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "Update_DateTime_UTC",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 10, 19, 22, 10, 18, 729, DateTimeKind.Utc).AddTicks(629),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 10, 20, 16, 30, 5, 681, DateTimeKind.Utc).AddTicks(6610));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Server_DateTime",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 10, 20, 1, 10, 18, 729, DateTimeKind.Local).AddTicks(25),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 10, 20, 19, 30, 5, 681, DateTimeKind.Local).AddTicks(5975));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateTime_UTC",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 10, 19, 22, 10, 18, 729, DateTimeKind.Utc).AddTicks(365),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 10, 20, 16, 30, 5, 681, DateTimeKind.Utc).AddTicks(6295));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Update_DateTime_UTC",
                table: "Accounts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 10, 19, 22, 10, 18, 728, DateTimeKind.Utc).AddTicks(8917),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 10, 20, 16, 30, 5, 681, DateTimeKind.Utc).AddTicks(4746));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Server_DateTime",
                table: "Accounts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 10, 20, 1, 10, 18, 728, DateTimeKind.Local).AddTicks(8214),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 10, 20, 19, 30, 5, 681, DateTimeKind.Local).AddTicks(4009));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateTime_UTC",
                table: "Accounts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 10, 19, 22, 10, 18, 728, DateTimeKind.Utc).AddTicks(8606),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 10, 20, 16, 30, 5, 681, DateTimeKind.Utc).AddTicks(4458));

            migrationBuilder.AlterColumn<double>(
                name: "Balance",
                table: "Accounts",
                type: "float",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");
        }
    }
}
