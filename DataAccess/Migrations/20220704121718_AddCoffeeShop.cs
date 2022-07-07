using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class AddCoffeeShop : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql($"Insert into CoffeeShops(ShopName,OpeningHours,Address) Values('Coffee of New Orleans','9-5 mon-sat','west local baffalo NY')");
            migrationBuilder.Sql($"Insert into CoffeeShops(ShopName,OpeningHours,Address) Values('Coffee of Atlanata','10-5 mon-sat','west local')");
            migrationBuilder.Sql($"Insert into CoffeeShops(ShopName,OpeningHours,Address) Values('Coffee of NewYork','9-10 mon-sat','local baffalo NY')");
            migrationBuilder.Sql($"Insert into CoffeeShops(ShopName,OpeningHours,Address) Values('Coffee of Washington','8-5 mon-sat','baffalo NY')");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
