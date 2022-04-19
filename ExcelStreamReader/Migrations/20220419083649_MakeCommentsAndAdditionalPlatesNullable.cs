using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExcelStreamReader.Migrations
{
    public partial class MakeCommentsAndAdditionalPlatesNullable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Comment",
                table: "LtCustomers",
                type: "character varying(724)",
                maxLength: 724,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(724)",
                oldMaxLength: 724);

            migrationBuilder.AlterColumn<string>(
                name: "AdditionalPlateNumbers",
                table: "LtCustomers",
                type: "character varying(724)",
                maxLength: 724,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(724)",
                oldMaxLength: 724);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Comment",
                table: "LtCustomers",
                type: "character varying(724)",
                maxLength: 724,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "character varying(724)",
                oldMaxLength: 724,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "AdditionalPlateNumbers",
                table: "LtCustomers",
                type: "character varying(724)",
                maxLength: 724,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "character varying(724)",
                oldMaxLength: 724,
                oldNullable: true);
        }
    }
}
