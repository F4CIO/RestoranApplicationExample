using System;
using System.Collections.Generic;
using System.Linq;

using F4CIO.Restro.Data;
using F4CIO.Restro.Entities;
using Microsoft.Extensions.DependencyInjection;

namespace F4CIO.Restro.BusinessLogic
{
    public interface IHandlerForOrders
    {
        List<Order> GetOrders();

        void InsertOrder(Order order);
    }

    public class HandlerForOrders: IHandlerForOrders
    {
        private F4CIO.Restro.Data.IHandlerForOrders _dlHandlerForOrders;

        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<F4CIO.Restro.Data.IHandlerForOrders, F4CIO.Restro.Data.HandlerForOrders>();
            F4CIO.Restro.Data.HandlerForOrders.ConfigureServices(services);
        }

        public HandlerForOrders(F4CIO.Restro.Data.IHandlerForOrders dlHandlerForOrders)
        {
            this._dlHandlerForOrders = dlHandlerForOrders;
        }

        public List<Order> GetOrders()
        {
            var r = this._dlHandlerForOrders.GetOrders();
            //do any business logic here...
            return r;
        }

        public void InsertOrder(Order order)
        {
            Order m = new Order();
            m.Date = order.Date;
            m.Status = order.Status;
            m.Summary = order.Summary;
            //do any business logic here...
            this._dlHandlerForOrders.InsertOrder(m);
        }
    }
}
