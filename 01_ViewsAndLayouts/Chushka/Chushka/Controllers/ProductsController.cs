using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Chushka.Data;
using Chushka.Models;
using Chushka.Models.Enums;
using Chushka.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Chushka.Controllers
{
    public class ProductsController : Controller
    {
        private ChushkaDbContext chushkaDbContext;

        public ProductsController(ChushkaDbContext chushkaDbContext)
        {
            this.chushkaDbContext = chushkaDbContext;
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var product = chushkaDbContext.Products.FirstOrDefault(p => p.Id == id);

            return this.View(new ProductsDetailsViewModel
            {
                Description = product.Description,
                Name = product.Name,
                Price = product.Price,
                Type = product.Type.ToString(),
                Id = product.Id
            });
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult Create()
        {
            return this.View();
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> Create(ProductsCreateViewModel model)
        {
            var product = new Product
            {
                Description = model.Description,
                Name = model.Name,
                Price = model.Price,
                Type = model.Type
            };
            await this.chushkaDbContext.Products.AddAsync(product);
            await this.chushkaDbContext.SaveChangesAsync();
            return this.RedirectToAction("Index", "Home");
        }
        
        [HttpGet]
        public IActionResult Edit()
        {
            return this.View();
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult Edit(int id, ProductsDetailsViewModel model)
        {
            var product = chushkaDbContext.Products.FirstOrDefault(p => p.Id == id);
            product.Name = model.Name;
            product.Description = model.Description;
            product.Price = model.Price;
            ProductType type;
            Enum.TryParse(model.Type, out type);
            product.Type = type;
            chushkaDbContext.Products.Update(product);
            chushkaDbContext.SaveChanges();
            return this.RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult Delete()
        {
            return this.View();
        }


        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult Delete(int id)
        {
            var product = chushkaDbContext.Products.FirstOrDefault(p => p.Id == id);
            chushkaDbContext.Products.Remove(product);
            chushkaDbContext.SaveChanges();
            return this.RedirectToAction("Index", "Home");
        }
    }
}
