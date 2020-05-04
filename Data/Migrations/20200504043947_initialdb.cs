using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RentCars.Migrations
{
    public partial class initialdb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ClientDatas",
                columns: table => new
                {
                    ClientId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    MiddleName = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    IdNumber = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientDatas", x => x.ClientId);
                });

            migrationBuilder.CreateTable(
                name: "Locations",
                columns: table => new
                {
                    LocationId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    VenueName = table.Column<string>(nullable: true),
                    Address1 = table.Column<string>(nullable: true),
                    Address2 = table.Column<string>(nullable: true),
                    Address3 = table.Column<string>(nullable: true),
                    CityTown = table.Column<string>(nullable: true),
                    StateProvince = table.Column<string>(nullable: true),
                    PostalCode = table.Column<string>(nullable: true),
                    Country = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.LocationId);
                });

            migrationBuilder.CreateTable(
                name: "Rents",
                columns: table => new
                {
                    CarId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Marca = table.Column<string>(nullable: true),
                    Model = table.Column<string>(nullable: true),
                    LocationId = table.Column<int>(nullable: true),
                    StartDate = table.Column<DateTime>(nullable: false),
                    Zile = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rents", x => x.CarId);
                    table.ForeignKey(
                        name: "FK_Rents_Locations_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Locations",
                        principalColumn: "LocationId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Price",
                columns: table => new
                {
                    AsigId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RentCarId = table.Column<int>(nullable: true),
                    NumeAsig = table.Column<string>(nullable: true),
                    Level = table.Column<int>(nullable: false),
                    ClientDataClientId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Price", x => x.AsigId);
                    table.ForeignKey(
                        name: "FK_Price_ClientDatas_ClientDataClientId",
                        column: x => x.ClientDataClientId,
                        principalTable: "ClientDatas",
                        principalColumn: "ClientId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Price_Rents_RentCarId",
                        column: x => x.RentCarId,
                        principalTable: "Rents",
                        principalColumn: "CarId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "ClientDatas",
                columns: new[] { "ClientId", "Address", "City", "Email", "FirstName", "IdNumber", "LastName", "MiddleName", "Phone" },
                values: new object[,]
                {
                    { 1, "Aleea Eprubetei 21-23", "Bucuresti", "marin.cezar45@gmail.com", "Cezar", "963747", "Marin", null, "0755356570" },
                    { 2, "Aleea Eprubetei 21-23", "Bucuresti", "marin.irina@gmail.com", "Irina", "963748", "Marin", null, "0755356570" }
                });

            migrationBuilder.InsertData(
                table: "Locations",
                columns: new[] { "LocationId", "Address1", "Address2", "Address3", "CityTown", "Country", "PostalCode", "StateProvince", "VenueName" },
                values: new object[] { 1, "Calea Bucurestilor 210", null, null, "Otopeni", "ROU", "12345", "IF", "Otopeni Auto" });

            migrationBuilder.InsertData(
                table: "Price",
                columns: new[] { "AsigId", "ClientDataClientId", "Level", "NumeAsig", "RentCarId" },
                values: new object[,]
                {
                    { 1, null, 1, null, null },
                    { 2, null, 3, "Asigurare Basic", null }
                });

            migrationBuilder.InsertData(
                table: "Rents",
                columns: new[] { "CarId", "LocationId", "Marca", "Model", "StartDate", "Zile" },
                values: new object[] { 1, 1, "Volkswagen", "Golf", new DateTime(2020, 10, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 });

            migrationBuilder.CreateIndex(
                name: "IX_Price_ClientDataClientId",
                table: "Price",
                column: "ClientDataClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Price_RentCarId",
                table: "Price",
                column: "RentCarId");

            migrationBuilder.CreateIndex(
                name: "IX_Rents_LocationId",
                table: "Rents",
                column: "LocationId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Price");

            migrationBuilder.DropTable(
                name: "ClientDatas");

            migrationBuilder.DropTable(
                name: "Rents");

            migrationBuilder.DropTable(
                name: "Locations");
        }
    }
}
