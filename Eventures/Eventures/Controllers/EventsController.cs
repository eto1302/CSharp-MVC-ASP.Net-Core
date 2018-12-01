using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Security.Principal;
using System.Security.Claims;
using Eventures.Attributes;
using Eventures.Data;
using Eventures.Models;
using Eventures.Services;
using Eventures.Services.Contracts;
using Eventures.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Remotion.Linq.Parsing.Structure.IntermediateModel;
using Microsoft.EntityFrameworkCore;

namespace Eventures.Controllers
{
    public class EventsController : Controller
    {

        public UserManager<EventuresUser> userManager { get; set; }
        public IEventService eventService { get; set; }

        public EventsController(ApplicationDbContext dbContext, ILogger<EventsController> logger, UserManager<EventuresUser> userManager, IEventService eventService)
        {
            this.DbContext = dbContext;
            this.logger = logger;
            this.userManager = userManager;
            this.eventService = eventService;
        }

        private readonly ApplicationDbContext DbContext;
        private readonly ILogger logger;

        [HttpGet]
        [Authorize]
        public IActionResult All()
        {
            return this.View(this.DbContext.Events.ToList());
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
        public async Task<IActionResult> Create(CreateEventsViewModel model)
        {
            var eventVar = new Event
            {
                Name = model.Name,
                Place = model.Place,
                Start = model.Start,
                End = model.End,
                TotalTickets = model.TotalTickets,
                PricePerTicket = model.PricePerTicket
            };
            await this.DbContext.Events.AddAsync(eventVar);
            await this.DbContext.SaveChangesAsync();
            this.logger.LogInformation($"{DateTime.Now} Administrator {this.User.Identity.Name} create event {eventVar.Name} ({eventVar.Start} / {eventVar.End})");
            return this.RedirectToAction("Index", "Home");
        }


        [HttpGet]
        [Authorize]
        public async Task<IActionResult> MyEvents()
        {
            List<MyEventsViewModel> events = new List<MyEventsViewModel>();
            EventuresUser user = await this.userManager.GetUserAsync(this.User);
            var orders = this.DbContext.Orders.Include(o => o.Event).Where(o => o.Customer == user).ToList();
            foreach (var o in orders)
            {
                events.Add(new MyEventsViewModel
                {
                    End = o.Event.End.ToString("dd-MMM-yy hh:mm:ss"),
                    Name = o.Event.Name,
                    Start = o.Event.Start.ToString("dd-MMM-yy hh:mm:ss"),
                    Tickets = o.TicketsCount
                });
            }

            return this.View(events);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Order(OrderEventViewModel model)
        {

            model.User = await this.userManager.GetUserAsync(this.User);
            await this.DbContext.Orders.AddAsync(new Order
            {
                Customer = model.User,
                Event = this.DbContext.Events.ToList().FirstOrDefault(e => e.Id == model.EventId),
                OrderedOn = DateTime.Now,
                TicketsCount = model.TicketsCount
            });
            this.DbContext.SaveChanges();
            return RedirectToAction("All", "Events");
        }
    }
}
