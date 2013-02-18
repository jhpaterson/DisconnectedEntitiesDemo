using System.Collections.Generic;

namespace DisconnectedEntitiesDemo.Models
{
    public class OrderChanges
    {
        public Order Order { get; set; }
        public List<OrderLine> DeletedLines { get; set; }
    }
}