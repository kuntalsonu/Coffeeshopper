using API.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CoffeeShopController : ControllerBase
    {
        private readonly ICoffeeShopService coffeeShopService;
        public CoffeeShopController(ICoffeeShopService coffeeShopService)
        {
            this.coffeeShopService = coffeeShopService;
        }
        [HttpGet]
        public async Task<IActionResult> List()
        {
            var coffeeshop = await coffeeShopService.List();
            return Ok(coffeeshop);
        }
    }
}
