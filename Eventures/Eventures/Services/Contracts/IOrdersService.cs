using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Eventures.Models;
using Eventures.ViewModels;

namespace Eventures.Services
{
    public interface IOrdersService
    {
        List<Order> GetMyOrders(EventuresUser User);

        void Order(OrderEventViewModel model);

        List<AllOrdersViewModel> GetAll();
    }
}
