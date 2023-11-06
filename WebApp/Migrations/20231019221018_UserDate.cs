using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApp.Migrations
{
    /// <inheritdoc />
    public partial class UserDate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "Update_DateTime_UTC",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 10, 19, 22, 10, 18, 729, DateTimeKind.Utc).AddTicks(629),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValueSql: "GETUTCDATE()");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Server_DateTime",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 10, 20, 1, 10, 18, 729, DateTimeKind.Local).AddTicks(25),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValueSql: "GETDATE()");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateTime_UTC",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 10, 19, 22, 10, 18, 729, DateTimeKind.Utc).AddTicks(365),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValueSql: "GETUTCDATE()");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Update_DateTime_UTC",
                table: "Accounts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 10, 19, 22, 10, 18, 728, DateTimeKind.Utc).AddTicks(8917),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 10, 19, 22, 3, 51, 356, DateTimeKind.Utc).AddTicks(8315));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Server_DateTime",
                table: "Accounts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 10, 20, 1, 10, 18, 728, DateTimeKind.Local).AddTicks(8214),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 10, 20, 1, 3, 51, 356, DateTimeKind.Local).AddTicks(7271));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateTime_UTC",
                table: "Accounts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 10, 19, 22, 10, 18, 728, DateTimeKind.Utc).AddTicks(8606),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 10, 19, 22, 3, 51, 356, DateTimeKind.Utc).AddTicks(7849));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "Update_DateTime_UTC",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "GETUTCDATE()",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 10, 19, 22, 10, 18, 729, DateTimeKind.Utc).AddTicks(629));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Server_DateTime",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "GETDATE()",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 10, 20, 1, 10, 18, 729, DateTimeKind.Local).AddTicks(25));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateTime_UTC",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "GETUTCDATE()",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 10, 19, 22, 10, 18, 729, DateTimeKind.Utc).AddTicks(365));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Update_DateTime_UTC",
                table: "Accounts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 10, 19, 22, 3, 51, 356, DateTimeKind.Utc).AddTicks(8315),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 10, 19, 22, 10, 18, 728, DateTimeKind.Utc).AddTicks(8917));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Server_DateTime",
                table: "Accounts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 10, 20, 1, 3, 51, 356, DateTimeKind.Local).AddTicks(7271),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 10, 20, 1, 10, 18, 728, DateTimeKind.Local).AddTicks(8214));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateTime_UTC",
                table: "Accounts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 10, 19, 22, 3, 51, 356, DateTimeKind.Utc).AddTicks(7849),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 10, 19, 22, 10, 18, 728, DateTimeKind.Utc).AddTicks(8606));
        }
    }
}
