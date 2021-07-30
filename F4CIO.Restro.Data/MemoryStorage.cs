using F4CIO.Restro.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace F4CIO.Restro.Data
{
    public interface IMemoryStorage
    {
        List<Order> _orders { get; set; }
    }

    /// <summary>
    /// Trivial implementation -for assignment purposes only
    /// </summary>
    public class MemoryStorage:IMemoryStorage
    {
        private List<Order> _orders = new List<Order>();

        List<Order> IMemoryStorage._orders { get => _orders; set => _orders = value; }

    }
}
