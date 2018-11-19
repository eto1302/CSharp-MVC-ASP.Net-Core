using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Chushka.Data;
using Microsoft.AspNetCore.Mvc;
using Chushka.Models;
using Chushka.ViewModels;

namespace Chushka.Controllers
{
    public class HomeController : Controller
    {
        public ChushkaDbContext ChushkaDbContext;

        public HomeController(ChushkaDbContext chushkaDbContext)
        {
            ChushkaDbContext = chushkaDbContext;
        }

        public IActionResult Index()
        {
            if (!this.User.Identity.IsAuthenticated)
            {
                return View();
            }
            
            var products = this.ChushkaDbContext.Products;
            List<ProductListViewModel> productListViewModels = products.Select(p => new ProductListViewModel
            {
                Id = p.Id,
                Name = p.Name,
                Description = p.Description,
                Price = p.Price
            }).ToList();

            return this.View(productListViewModels);
        }

        
    }
}
