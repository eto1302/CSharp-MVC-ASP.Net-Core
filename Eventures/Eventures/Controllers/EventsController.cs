using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Eventures.Attributes;
using Eventures.Data;
using Eventures.Models;
using Eventures.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Remotion.Linq.Parsing.Structure.IntermediateModel;

namespace Eventures.Controllers
{
    public class EventsController : Controller
    {
        public EventsController(ApplicationDbContext dbContext, ILogger<EventsController> logger)
        {
            DbContext = dbContext;
            this.logger = logger;
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
    }
}
