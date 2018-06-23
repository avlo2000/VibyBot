using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VibyBot.Persistence.Contracts;
using VibyBot.Persistence.DTO;

namespace VibyBot.ControlTests.Mockups
{
    public class OrderStorageMock : IOrderStorage
    {
        private static List<Order> _allOrders;

        public OrderStorageMock()
        {
            if (_allOrders == null)
                _allOrders = new List<Order>();
        }

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
            List<Order> _clientOrders = new List<Order>();
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
            for (int i = 0; i < _allOrders.Count; i++)
            {
                if (_allOrders[i].OrderId == order.OrderId)
                {
                    _allOrders[i] = order;
                }
                else
                {
                    _allOrders.Add(order);
                }
            }
        }
    }
}
