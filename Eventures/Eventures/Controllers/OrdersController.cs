using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Eventures.Services;
using Eventures.Services.Contracts;
using Eventures.Web.Models;
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
        public async Task<IActionResult> All()
        {
            var orders = (await this.ordersService.GetAll())
                .Select(Mapper.Map<OrderListingViewModel>);

            return this.View(orders);
        }
    }
}