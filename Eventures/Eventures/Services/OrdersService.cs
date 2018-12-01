using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Eventures.Data;
using Eventures.Models;
using Eventures.Services.Contracts;
using Eventures.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace Eventures.Services
{
    public class OrdersService : IOrdersService
    {
        public OrdersService(ApplicationDbContext context, IEventService eventService)
        {
            this.context = context;
            this.eventService = eventService;
        }

        public ApplicationDbContext context { get; set; }
        public IEventService eventService { get; set; }

        public List<Order> GetMyOrders(EventuresUser User)
        {
            var orders = this.context.Orders.Include(o => o.Event).Where(o => o.Customer == User).ToList();
            return orders;
        }

        public async void Order(OrderEventViewModel model)
        {
            await this.context.Orders.AddAsync(new Order
            {
                Customer = model.User,
                Event = eventService.GetEventById(model.EventId),
                OrderedOn = DateTime.Now,
                TicketsCount = model.TicketsCount
            });
        }

        public List<AllOrdersViewModel> GetAll()
        {
            List<Order> orders = this.context.Orders.Include(o => o.Event).ToList();
            List<AllOrdersViewModel> result = new List<AllOrdersViewModel>();
            foreach (var order in orders)
            {
                result.Add(new AllOrdersViewModel
                {
                   CustomerName = order.Customer.UserName,
                   EventName = order.Event.Name,
                   OrderedOn = order.OrderedOn.ToString("dd-MMM-yy hh:mm:ss")
                });
            }

            return result;
        }
    }
}
