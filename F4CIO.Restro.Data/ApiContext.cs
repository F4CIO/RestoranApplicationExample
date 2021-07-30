using System;
using Microsoft.EntityFrameworkCore;

using F4CIO.Restro.Entities;

namespace F4CIO.Restro.Data
{
    public class ApiContext : DbContext
    {
        public ApiContext(DbContextOptions<ApiContext> options)
           : base(options)
        {
        }

        public DbSet<Order> Orders { get; set; }
    }
}
