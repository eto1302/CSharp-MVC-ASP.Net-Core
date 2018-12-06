using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Security.Principal;
using System.Security.Claims;
using AutoMapper;
using Eventures.Attributes;
using Eventures.Data;
using Eventures.Models;
using Eventures.Services;
using Eventures.Services.Contracts;
using Eventures.Services.Models;
using Eventures.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Remotion.Linq.Parsing.Structure.IntermediateModel;
using Microsoft.EntityFrameworkCore;
using X.PagedList;

namespace Eventures.Controllers
{
    public class EventsController : Controller
    {

        public UserManager<EventuresUser> userManager { get; set; }
        public IEventsService eventService { get; set; }
        public IOrdersService orderService { get; set; }
        public EventsController(ApplicationDbContext dbContext, ILogger<EventsController> logger, UserManager<EventuresUser> userManager, IEventsService eventService, IOrdersService orderService)
        {
            this.DbContext = dbContext;
            this.logger = logger;
            this.userManager = userManager;
            this.eventService = eventService;
            this.orderService = orderService;
        }

        private readonly ApplicationDbContext DbContext;
        private readonly ILogger logger;

        [HttpGet]
        [Authorize]
        public IActionResult All(int? page)
        {
            var events = this.eventService.GetAll();
            
            var viewModels = new List<EventListingViewModel>();
            foreach (var eventureEvent in events)
            {
                var eventViewModel = Mapper.Map<EventListingViewModel>(eventureEvent);
                viewModels.Add(eventViewModel);
            }
            var nextPage = page ?? 1;
            var pagedViewModels = viewModels.ToPagedList(nextPage, 3);
            return this.View(pagedViewModels);
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        [TypeFilter(typeof(AdminLoggingCreateEventAttribute))]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create(EventCreateBindingModel model)
        {
            
            var serviceModel = Mapper.Map<EventServiceModel>(model);

            await this.eventService.CreateAsync(serviceModel);

            this.logger.LogInformation("Event created: " + serviceModel.Name, serviceModel);

            return this.RedirectToAction("All");
        }


        [HttpGet]
        [Authorize]
        public async Task<IActionResult> MyEvents()
        {
            var orders = (await this.orderService
                    .GetAllForUser(this.User.Identity.Name))
                .Select(Mapper.Map<OrderListingViewModel>);

            return this.View(orders);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Order(OrderCreateBindingModel model)
        {

            var serviceModel = Mapper.Map<OrderServiceModel>(model);

            serviceModel.OrderedOn = DateTime.Now;

            var result = await this.orderService.Create(serviceModel, this.User.Identity.Name);
            if (!result)
            {
                return this.RedirectToAction("All", "Events");
            }

            return this.RedirectToAction("MyEvents", "Events");
        }
    }
}
