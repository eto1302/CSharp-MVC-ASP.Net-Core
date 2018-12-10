using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Authentication.ExtendedProtection;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Eventures.Data;
using Eventures.Models;
using Eventures.Services;
using Eventures.Services.Contracts;
using Eventures.Services.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Shouldly;
using Xunit;

namespace Eventures.Tests
{
    public class EventsServiceTests : BaseTest
    {
        [Fact]
        public async Task All_WithExistingData_ShouldReturnAllOfExistingData()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;
            var context = new ApplicationDbContext(options);
            var eventsService = new EventsService(context);
            object[] models =
            {
                new Event
                {
                    Name = "Test Event 1",
                    Place = "Test Place 1",
                    StartDate = DateTime.UtcNow,
                    EndDate = DateTime.UtcNow,
                    TotalTickets = 2,
                    PricePerTicket = 2
                },
                new Event
                {
                    Name = "Test Event 2",
                    Place = "Test Place 2",
                    StartDate = DateTime.UtcNow,
                    EndDate = DateTime.UtcNow,
                    TotalTickets = 3,
                    PricePerTicket = 3
                }
            };
            await context.AddRangeAsync(models);
            await context.SaveChangesAsync();
            // Act
            var count = (eventsService.GetAll()).Count();
            // Assert
            Assert.Equal(2, count);
        }

        [Fact]
        public async Task All_WithExistingData_ShouldReturnAllOfExistingDataWithTickets()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;
            var context = new ApplicationDbContext(options);
            var eventsService = new EventsService(context);
            object[] models =
            {
                new Event
                {
                    Name = "Test Event 1",
                    Place = "Test Place 1",
                    StartDate = DateTime.UtcNow,
                    EndDate = DateTime.UtcNow,
                    TotalTickets = 2,
                    PricePerTicket = 2
                },
                new Event
                {
                    Name = "Test Event 2",
                    Place = "Test Place 2",
                    StartDate = DateTime.UtcNow,
                    EndDate = DateTime.UtcNow,
                    TotalTickets = 0,
                    PricePerTicket = 3
                }
            };
            await context.AddRangeAsync(models);
            await context.SaveChangesAsync();
            // Act
            var count = (eventsService.GetAll()).Count();
            // Assert
            Assert.Equal(1, count);
        }

        [Fact]
        public async Task Create_WithInvalidData_ShouldNotIncludeIntoDatabase()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;
            var context = new ApplicationDbContext(options);
            var eventsService = new EventsService(context);
            EventServiceModel model = new EventServiceModel
            {
                Name = "Test",
                Place = "Test Place 2",
                StartDate = DateTime.UtcNow,
                EndDate = DateTime.UtcNow,
                TotalTickets = 0,
                PricePerTicket = 3
            };

            await eventsService.CreateAsync(model);
            // Act
            var count = (eventsService.GetAll()).Count();
            // Assert
            Assert.Equal(0, count);
        }

        [Fact]
        public async Task Create_WithValidData_ShouldIncludeIntoDatabase()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;
            var context = new ApplicationDbContext(options);
            var eventsService = new EventsService(context);
            EventServiceModel model = new EventServiceModel
            {
                Name = "Test Place 1",
                Place = "somewhere",
                StartDate = DateTime.UtcNow,
                EndDate = DateTime.UtcNow,
                TotalTickets = 5,
                PricePerTicket = 4.8m
            };

            await eventsService.CreateAsync(model);
            // Act
            var count = (eventsService.GetAll()).Count();
            // Assert
            Assert.Equal(1, count);
        }
    }
}
