using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.Entity;
using DisconnectedEntitiesDemo.Models;
using System.Data;

namespace DisconnectedEntitiesDemo.Controllers
{
    public class OrdersController : ApiController
    {
        private OrdersContext db = new OrdersContext();

        // GET api/orders
        public IEnumerable<Order> Get()
        {
            return db.Orders
                .Include(o => o.Customer)
                .Include(o => o.OrderLines)
                .ToList();
        }

        // GET api/orders/5
        public Order Get(int id)
        {
            return db.Orders
               .Where(o => o.OrderId == id)
               .Include(o => o.Customer)
               .Include(o => o.OrderLines)
               .FirstOrDefault();
        }

        // POST api/values
        public void Post(OrderChanges orderChanges)
        {
            // not part of procedure - demo effect of attaching graph which references a currently tracked object
            var cust = db.Customers.Find(1);     // customer 1 is now being tracked

            if (ModelState.IsValid)
            {
                db.Orders.Add(orderChanges.Order);

                // not part of procedure - demo effect of attaching graph which references a currently tracked object
                var orderState = db.Entry(orderChanges.Order).State;
                var customerState = db.Entry(orderChanges.Order.Customer).State;       // customer 1, currently tracked 

                if (orderChanges.Order.OrderId > 0)
                {
                    db.Entry(orderChanges.Order).State = EntityState.Modified;
                }

                foreach (var orderLine in orderChanges.Order.OrderLines)
                {
                    if (orderLine.OrderLineId > 0)
                    {
                        db.Entry(orderLine).State = EntityState.Modified;
                    }
                }

                foreach (var orderLine in orderChanges.DeletedLines)
                {
                    db.Entry(orderLine).State = EntityState.Deleted;
                }

                db.SaveChanges();
            }      
        }

        // PUT api/values/5
        public void Put(int id, Order order)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}