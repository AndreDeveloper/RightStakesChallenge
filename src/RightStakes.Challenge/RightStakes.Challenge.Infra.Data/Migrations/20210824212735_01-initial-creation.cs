using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RightStakes.Challenge.Infra.Data.Migrations
{
    public partial class _01initialcreation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CryptoCurrency",
                columns: table => new
                {
                    Uid = table.Column<Guid>(nullable: false),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    Id = table.Column<string>(nullable: true),
                    Symbol = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Image = table.Column<string>(nullable: true),
                    CurrentPrice = table.Column<decimal>(nullable: false),
                    MarketCap = table.Column<long>(nullable: false),
                    MarketCapRank = table.Column<int>(nullable: false),
                    FullyDilutedValuation = table.Column<long>(nullable: false),
                    TotalVolume = table.Column<long>(nullable: false),
                    High24h = table.Column<decimal>(nullable: true),
                    Low24h = table.Column<decimal>(nullable: true),
                    PriceChange24h = table.Column<decimal>(nullable: true),
                    PriceChangePercentage24h = table.Column<decimal>(nullable: true),
                    MarketCapChange24h = table.Column<decimal>(nullable: true),
                    MarketCapChangePercentage24h = table.Column<decimal>(nullable: true),
                    CirculatingSupply = table.Column<decimal>(nullable: true),
                    TotalSupply = table.Column<decimal>(nullable: true),
                    MaxSupply = table.Column<decimal>(nullable: true),
                    Ath = table.Column<decimal>(nullable: true),
                    AthChangePercentage = table.Column<decimal>(nullable: true),
                    AthDate = table.Column<DateTime>(nullable: false),
                    Atl = table.Column<decimal>(nullable: true),
                    AtlChangePercentage = table.Column<decimal>(nullable: true),
                    AtlDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CryptoCurrency", x => x.Uid);
                });

            migrationBuilder.CreateTable(
                name: "Quote",
                columns: table => new
                {
                    Uid = table.Column<Guid>(nullable: false),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Value = table.Column<decimal>(nullable: false),
                    LastUpdate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Quote", x => x.Uid);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CryptoCurrency");

            migrationBuilder.DropTable(
                name: "Quote");
        }
    }
}
