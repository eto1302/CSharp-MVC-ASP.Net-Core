using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Eventures.Data;
using Eventures.Models;
using Eventures.Services;
using Eventures.Services.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Xunit;

namespace Eventures.Tests.Eventures.Web.Services.Tests.Orders
{
    public class OrdersServiceTests : BaseTest
    {
        [Fact]
        public async Task All_WithData_ShouldReturnData()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;
            var context = new ApplicationDbContext(options);
            var ordersService = new OrdersService(context);

            var testEvent = new Event
            {
                Name = "TestEvent123",
                TotalTickets = 30,
                StartDate = DateTime.UtcNow,
                EndDate = DateTime.UtcNow,
                Place = "somewhere",
                PricePerTicket = 30
            };
            await context.Events.AddAsync(testEvent);

            var user = new EventuresUser
            {
                UserName = "TestUser"
            };
            await context.Users.AddAsync(user);

            var orders = new[]
            {
                new Order
                {
                    OrderedOn = DateTime.UtcNow,
                    TicketsCount = 12,
                    Event = testEvent,
                    User = user
                },
                new Order
                {
                    OrderedOn = DateTime.UtcNow,
                    TicketsCount = 23,
                    Event = testEvent,
                    User = user
                },
                new Order
                {
                    OrderedOn = DateTime.UtcNow,
                    TicketsCount = 34,
                    Event = testEvent,
                    User = user
                }
            };
            await context.Orders.AddRangeAsync(orders);

            await context.SaveChangesAsync();

            // Assert
            var count = (await ordersService.GetAll()).Count();
            Assert.Equal(3, count);
        }

        [Fact]
        public async Task All_WithoutData_ShouldReturnNoData()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;
            var context = new ApplicationDbContext(options);
            var ordersService = new OrdersService(context);

            // Act
            var count = (await ordersService.GetAll()).Count();
            // Assert
            Assert.Equal(0, count);
        }

        [Fact]
        public async Task Create_WithValidModel_ShouldAddToDatabase()
        {
            // Arrange
            const int ticketsCount = 10;

            var context = new ApplicationDbContext(new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options);
            var ordersService = new OrdersService(context);

            var user = new EventuresUser
            {
                UserName = "TestUser"
            };
            await context.Users.AddAsync(user);

            var eventModel = new Event
            {
                Name = "TestEvent123",
                TotalTickets = ticketsCount
            };
            await context.Events.AddAsync(eventModel);

            await context.SaveChangesAsync();

            var model = new OrderServiceModel
            {
                OrderedOn = DateTime.UtcNow,
                EventId = eventModel.Id,
                TicketsCount = 2
            };

            // Act
            var result = await ordersService.Create(model, user.UserName);

            // Assert
            Assert.True(result);

            var remainingTickets = (await context.Events.SingleAsync()).TotalTickets;
            Assert.Equal(ticketsCount - model.TicketsCount, remainingTickets);

            var count = await context.Orders.CountAsync();
            Assert.Equal(1, count);

            var orderUserId = (await context.Orders.SingleAsync()).UserId;
            Assert.Equal(user.Id, orderUserId);
        }

        [Fact]
        public async Task Create_WithNullUser_ShouldntAddToDatabase()
        {
            // Arrange
            const int ticketsCount = 10;

            var context = new ApplicationDbContext(new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options);
            var ordersService = new OrdersService(context);

            var eventModel = new Event
            {
                Name = "TestEvent123",
                TotalTickets = ticketsCount
            };
            await context.Events.AddAsync(eventModel);

            await context.SaveChangesAsync();

            var model = new OrderServiceModel
            {
                OrderedOn = DateTime.UtcNow,
                EventId = eventModel.Id,
                TicketsCount = 2
            };

            // Act
            var result = await ordersService.Create(model, null);

            // Assert
            Assert.False(result);

            var remainingTickets = (await context.Events.SingleAsync()).TotalTickets;
            Assert.Equal(ticketsCount, remainingTickets);

            var count = await context.Orders.CountAsync();
            Assert.Equal(0, count);
        }

        [Fact]
        public async Task Create_WithoutEvent_ShouldNotAddToDatabase()
        {
            // Arrange
            var context = new ApplicationDbContext(new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options);
            var ordersService = new OrdersService(context);

            var user = new EventuresUser
            {
                UserName = "TestUser"
            };
            await context.Users.AddAsync(user);

            await context.SaveChangesAsync();

            var model = new OrderServiceModel
            {
                EventId = Guid.NewGuid().ToString(),
                TicketsCount = 2
            };

            // Act
            var result = await ordersService.Create(model, user.UserName);

            // Assert
            Assert.False(result);

            var count = await context.Orders.CountAsync();
            Assert.Equal(0, count);
        }

        [Fact]
        public async Task Create_WithNotEnoughAvailableTickets_ShouldNotAddToDatabase()
        {
            // Arrange
            const int ticketsCount = 10;

            var context = new ApplicationDbContext(new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options);
            var ordersService = new OrdersService(context);

            var user = new EventuresUser
            {
                UserName = "TestUser"
            };
            await context.Users.AddAsync(user);

            var eventModel = new Event
            {
                Name = "TestEvent123",
                TotalTickets = ticketsCount
            };
            await context.Events.AddAsync(eventModel);

            await context.SaveChangesAsync();

            var model = new OrderServiceModel
            {
                OrderedOn = DateTime.UtcNow,
                EventId = eventModel.Id,
                TicketsCount = 20
            };

            // Act
            var result = await ordersService.Create(model, user.UserName);

            // Assert
            Assert.False(result);

            var remainingTickets = (await context.Events.SingleAsync()).TotalTickets;
            Assert.Equal(ticketsCount, remainingTickets);

            var count = await context.Orders.CountAsync();
            Assert.Equal(0, count);
        }

    }
}

