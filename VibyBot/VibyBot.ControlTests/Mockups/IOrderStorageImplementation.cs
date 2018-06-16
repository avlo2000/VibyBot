using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VibyBot.Persistence.Contracts;
using VibyBot.Persistence.DTO;

namespace VibyBot.ControlTests.Mockups
{
    class IOrderStorageImplementation : IOrderStorage
    {
        private List<Order> _allOrders;
        private List<Order> _clientOrders;

        public void CloseOrder(long orderId)
        {
            foreach (var order in _allOrders)
            {
                if (order.OrderId == orderId)
                {
                    _allOrders.Remove(order);
                }
            }
        }

        public IEnumerable<Order> CurrentOrders(long userId)
        {
            
            foreach (var order in _allOrders)
            {
                if (order.ClientId == userId)
                {
                    _clientOrders.Add(order);
                }
            }
            return _clientOrders;
        }

        public IEnumerable<Order> GetAll()
        {
            return _allOrders;
        }

        public void UpdateOrder(Order order)
        {
            _allOrders.Add(order);
        }
    }
}
