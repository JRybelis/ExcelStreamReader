using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ExcelStreamReader.Migrations
{
    public partial class tinkering : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LtCustomers",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Deleted = table.Column<bool>(type: "boolean", nullable: false),
                    UsersLogId = table.Column<long>(type: "bigint", nullable: false),
                    Grid = table.Column<long>(type: "bigint", nullable: false),
                    PlateNumber = table.Column<string>(type: "character varying(51)", maxLength: 51, nullable: false),
                    ValidFrom = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    ValidTo = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    LtCustomerName = table.Column<string>(type: "character varying(331)", maxLength: 331, nullable: false),
                    LtcGroupId = table.Column<long>(type: "bigint", nullable: false),
                    Comment = table.Column<string>(type: "character varying(724)", maxLength: 724, nullable: false),
                    Enabled = table.Column<bool>(type: "boolean", nullable: false),
                    PincodeHash = table.Column<string>(type: "text", nullable: false),
                    CustomerId = table.Column<long>(type: "bigint", nullable: false),
                    LotPlaceId = table.Column<long>(type: "bigint", nullable: false),
                    VehicleType = table.Column<int>(type: "integer", nullable: false),
                    LtcGroupName = table.Column<string>(type: "character varying(331)", maxLength: 331, nullable: false),
                    CustomerName = table.Column<string>(type: "text", nullable: false),
                    CompanySlots = table.Column<int>(type: "integer", nullable: true),
                    PriceRateId = table.Column<int>(type: "integer", nullable: false),
                    CompanyDetailsId = table.Column<int>(type: "integer", nullable: false),
                    IsLtCustomerAdditionalPlate = table.Column<bool>(type: "boolean", nullable: false),
                    LotPlaceTitle = table.Column<string>(type: "character varying(331)", maxLength: 331, nullable: false),
                    AdditionalPlateNumbers = table.Column<string>(type: "character varying(724)", maxLength: 724, nullable: false),
                    PaymentOption = table.Column<int>(type: "integer", nullable: false),
                    IsInLot = table.Column<bool>(type: "boolean", nullable: false),
                    VehicleTypeTitle = table.Column<string>(type: "text", nullable: false),
                    UsersLogActionId = table.Column<int>(type: "integer", nullable: false),
                    TotalCount = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LtCustomers", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LtCustomers");
        }
    }
}
