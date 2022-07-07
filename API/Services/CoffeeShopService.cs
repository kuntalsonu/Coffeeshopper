using API.Models;
using DataAccess.Data;
using Microsoft.EntityFrameworkCore;

namespace API.Services
{
    public class CoffeeShopService:ICoffeeShopService
    {
        private readonly DatabaseContext dbContext;

        public CoffeeShopService(DatabaseContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<List<CoffeeShopModel>> List()
        {
         var coffeeshops=   await (from shop in dbContext.CoffeeShops
                   select new CoffeeShopModel()
                   {
                       Id = shop.Id,
                       ShopName = shop.ShopName,
                       OpeningHours = shop.OpeningHours,
                       Address = shop.Address,
                   }).ToListAsync();
            return coffeeshops;
        }
    }
}
