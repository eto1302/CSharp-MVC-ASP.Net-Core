using System.Threading.Tasks;
using Eventures.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Eventures.Controllers
{
    public class OrdersController : Controller
    {
        public OrdersController(IOrdersService ordersService)
        {
            this.ordersService = ordersService;
        }

        public IOrdersService ordersService { get; set; }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult All()
        {
            return this.View(ordersService.GetAll());
        }
    }
}