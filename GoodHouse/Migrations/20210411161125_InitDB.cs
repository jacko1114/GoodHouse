using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GoodHouse.Migrations
{
    public partial class InitDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HouseObjects",
                columns: table => new
                {
                    HouseObjectId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DealDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    County = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Region = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TotalPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SquareFeet = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SquareFeetUnitPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Floor = table.Column<int>(type: "int", nullable: false),
                    TotalFloor = table.Column<int>(type: "int", nullable: false),
                    HouseAge = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ImgUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Source = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Remark = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsParkingSpace = table.Column<bool>(type: "bit", nullable: false),
                    ParkingSpacePrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ParkingSpaceSqureFeet = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateUser = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EditeTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EditeUser = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HouseObjects", x => x.HouseObjectId);
                });

            migrationBuilder.CreateTable(
                name: "HousingLayouts",
                columns: table => new
                {
                    HousingLayoutId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Room = table.Column<int>(type: "int", nullable: false),
                    LivingRoom = table.Column<int>(type: "int", nullable: false),
                    Bathroom = table.Column<int>(type: "int", nullable: false),
                    HouseObjectId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateUser = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EditeTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EditeUser = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HousingLayouts", x => x.HousingLayoutId);
                    table.ForeignKey(
                        name: "FK_HousingLayouts_HouseObjects_HouseObjectId",
                        column: x => x.HouseObjectId,
                        principalTable: "HouseObjects",
                        principalColumn: "HouseObjectId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HousingLayouts_HouseObjectId",
                table: "HousingLayouts",
                column: "HouseObjectId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HousingLayouts");

            migrationBuilder.DropTable(
                name: "HouseObjects");
        }
    }
}
