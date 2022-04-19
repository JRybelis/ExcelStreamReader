using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExcelStreamReader.Migrations
{
    public partial class MakeBaseInterfacePropsNullable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>(
                name: "UsersLogId",
                table: "LtCustomers",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<long>(
                name: "TotalCount",
                table: "LtCustomers",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<string>(
                name: "LtcGroupName",
                table: "LtCustomers",
                type: "character varying(331)",
                maxLength: 331,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(331)",
                oldMaxLength: 331);

            migrationBuilder.AlterColumn<long>(
                name: "Grid",
                table: "LtCustomers",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<bool>(
                name: "Deleted",
                table: "LtCustomers",
                type: "boolean",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "boolean");

            migrationBuilder.AlterColumn<string>(
                name: "CustomerName",
                table: "LtCustomers",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>(
                name: "UsersLogId",
                table: "LtCustomers",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "TotalCount",
                table: "LtCustomers",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "LtcGroupName",
                table: "LtCustomers",
                type: "character varying(331)",
                maxLength: 331,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "character varying(331)",
                oldMaxLength: 331,
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "Grid",
                table: "LtCustomers",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "Deleted",
                table: "LtCustomers",
                type: "boolean",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "boolean",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CustomerName",
                table: "LtCustomers",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);
        }
    }
}
