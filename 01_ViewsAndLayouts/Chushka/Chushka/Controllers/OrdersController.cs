using System;
using System.Linq;
using Chushka.Data;
using Chushka.Models;
using Chushka.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Chushka.Controllers
{
    public class OrdersController : Controller
    {
        private ChushkaDbContext chushkaDbContext;

        public OrdersController(ChushkaDbContext chushkaDbContext)
        {
            this.chushkaDbContext = chushkaDbContext;
        }

        public IActionResult All()
        {
            var orders = (this.chushkaDbContext.Orders)
                .Select(o => new OrderListViewModel
                    {
                        Customer = o.Client.UserName,
                        Id = o.Id,
                        OrderedOn = o.OrderedOn.ToString("hh:mm dd/MM/yyyy"),
                        Product = o.Product.Name

                    }
                    )
                .ToArray();

            return this.View(orders);
        }

        public IActionResult Create(int id)
        {
            var product =  this.chushkaDbContext.Products.FirstOrDefault(p => p.Id == id);

            var user =  this.chushkaDbContext.Users.FirstOrDefault(u => u.UserName == this.User.Identity.Name);

            if (product == null || user == null)
            {
                return this.RedirectToAction("Index", "Home");
            }

            var order = new Order
            {
                Client = user,
                Product = product,
                OrderedOn = DateTime.Now
            };

            this.chushkaDbContext.Orders.Add(order);

            this.chushkaDbContext.SaveChanges();

            return this.RedirectToAction("Index", "Home");
        }
    }
}