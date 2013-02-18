using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;

namespace DisconnectedEntitiesDemo.Models
{
    public class OrdersContextInitializer : DropCreateDatabaseAlways<OrdersContext>
    {
        protected override void Seed(OrdersContext context)
        {
            base.Seed(context);

            Customer c1 = new Customer { Name = "Fernando" };
            Customer c2 = new Customer { Name = "Felipe" };

            Product p1 =  new Product { Description = "Steering wheel", UnitCost = 999.0m };
            Product p2 =  new Product { Description = "Brake disc", UnitCost = 299.0m };
            Product p3 =  new Product { Description = "Spark plug", UnitCost = 19.99m };
            Product p4 =  new Product { Description = "Alloy wheel", UnitCost = 199.0m };

            Order o1 = new Order
            {
                OrderDate = DateTime.Now,
                Customer = c1,
                OrderLines = new List<OrderLine>{
                    new OrderLine{Quantity = 1, Product = p1},
                    new OrderLine{Quantity = 2, Product = p2}
                }
            };

            context.Customers.Add(c1);
            context.Customers.Add(c2);

            context.Products.Add(p1);
            context.Products.Add(p2);
            context.Products.Add(p3);
            context.Products.Add(p4);

            context.Orders.Add(o1);

            context.SaveChanges();

        }
    }
}