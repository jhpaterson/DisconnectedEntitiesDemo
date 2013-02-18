using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;


namespace DisconnectedEntitiesDemo.Models
{
    public class OrdersContext : DbContext
    {
        public OrdersContext()
        {
            Database.SetInitializer<OrdersContext>(new OrdersContextInitializer());
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Customer> Customers { get; set; }
    }
}