using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Eventures.Data;
using Eventures.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace Eventures.Utilities
{
    public static class EventsSeeder
    {
        public static void Seed(IServiceProvider provider, ApplicationDbContext context)
        {
            for (int i = 0; i < 20; ++i)
            {
                context.Events.Add(new Event
                {
                    Name = "Event123456",
                    Place = "UnknownLocation",
                    StartDate = new DateTime(2018, 12, 10, 22, 30, 30),
                    EndDate = new DateTime(2019, 12, 10, 22, 30, 30),
                    Orders = new List<Order>(),
                    PricePerTicket = 22,
                    TotalTickets = 10
                });
                context.SaveChanges();
            }
        }
    }
}
