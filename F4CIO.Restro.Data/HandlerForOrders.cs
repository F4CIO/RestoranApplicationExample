using System;
using System.Collections.Generic;
using System.Linq;

using F4CIO.Restro.Data;
using F4CIO.Restro.Entities;
using Microsoft.Extensions.DependencyInjection;

namespace F4CIO.Restro.Data
{
    public interface IHandlerForOrders
    {
        List<Order> GetOrders();

        void InsertOrder(Order order);
    }

    public class HandlerForOrders: IHandlerForOrders
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IMemoryStorage, MemoryStorage>();
        }

        private IMemoryStorage _memoryStorage;        

        public HandlerForOrders(IMemoryStorage memoryStorage)
        {
            this._memoryStorage = memoryStorage;
        }

        public List<Order> GetOrders()
        {
            //usually EF methods are used here instead for pulling data from db and some post-processing...
            return this._memoryStorage._orders.ToList();           
        }

        public void InsertOrder(Order order)
        {
            //usually EF methods are used here instead for commiting data to db...
            Order m = new Order();
            m.Date = order.Date;
            m.Status = order.Status;
            m.Summary = order.Summary;
            this._memoryStorage._orders.Add(m);
        }
    }
}
