using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Eventures.Controllers;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;

namespace Eventures.Attributes
{
    public class AdminLoggingCreateEventAttribute : Attribute, IActionFilter
    {
        private readonly ILogger logger;

        public AdminLoggingCreateEventAttribute(ILogger<EventsController> logger)
        {
            this.logger = logger;
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            var dateAndTime = DateTime.Now.ToString("MM/dd/yyyy HH:mm", CultureInfo.InvariantCulture);
            var username = context.HttpContext.User.Identity.Name;
            var Name = context.HttpContext.Request.Form["Name"];
            var Start = context.HttpContext.Request.Form["Start"];
            var End = context.HttpContext.Request.Form["End"];

            var logInfo = $"[{dateAndTime}] Administrator {username} create event {Name} ({Start} / {End}).";

            this.logger.LogError(logInfo);
        }
        
    }
}
