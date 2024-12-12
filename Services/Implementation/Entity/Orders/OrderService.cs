﻿using System;
using System.Collections.Generic;
using System.Linq;
using GenosStore.Model.Entity.Orders;
using GenosStore.Model.Entity.User;
using GenosStore.Model.Repository.Interface;
using GenosStore.Services.Interface.Entity.Orders;

namespace GenosStore.Services.Implementation.Entity.Orders {
    public class OrderService: IOrderService {

        private IGenosStoreRepositories _repositories;
        private ICartService _cartService;
        private IOrderStatusService _orderStatusService;

        public OrderService(IGenosStoreRepositories repositories, ICartService cartService, IOrderStatusService orderStatusService) {
            _repositories = repositories;
            _cartService = cartService;
            _orderStatusService = orderStatusService;
        }

        public void Create(Order item) {
            _repositories.Orders.Orders.Create(item);
        }

        public Order Get(int id) {
            return _repositories.Orders.Orders.Get(id);
        }

        public List<Order> List() {
            return _repositories.Orders.Orders.List();
        }

        public void Update(Order item) {
            _repositories.Orders.Orders.Update(item);
        }

        public void Delete(int id) {
            _repositories.Orders.Orders.Delete(id);
        }
        
        public long CreateOrderFromCart(Customer customer) {
            var cart = customer.Cart;
            var orderItems = new List<OrderItems>();
            var status = _orderStatusService.GetFromString("Created");
            var order = new Order {
                Customer = customer,
                CreatedAt = DateTime.Now,
                OrderStatus = status,
            };
            
            foreach (var item in cart.Items) {
                var discount = item.Item.ActiveDiscount;
                orderItems.Add(
                    new OrderItems {
                        Order = order,
                        Item = item.Item,
                        BoughtFor = discount != null ? item.Item.Price * (1 - discount.Value): item.Item.Price,
                        Quantity = item.Quantity
                    }
                );
            }
            
            order.Items = orderItems;
            _cartService.ClearCart(customer);
            Create(order);
            _repositories.Save();
            return order.Id;
            
        }

        public double CalculateTotal(Order order) {
            return order.Items.Sum(i => i.BoughtFor * i.Quantity);
        }

        public List<Order> ListOfSpecificCustomer(Customer customer) {
	        return List().Where(o => o.Customer.Id == customer.Id).ToList();
        }

        public void ReceiveOrder(Order order) {
            order.OrderStatus = _orderStatusService.GetFromString("Received");
            Update(order);
            _repositories.Save();
        }

        public void CancelOrder(Order order) {
            order.OrderStatus = _orderStatusService.GetFromString("Cancelled");
            Update(order);
            _repositories.Save();
        }

        public List<Order> GetActiveOrders() {
            return List().Where(
                o => o.OrderStatus.Name != "Отменён" && o.OrderStatus.Name != "Получен"
            ).ToList();
        }

        public int Save() {
            return _repositories.Save();
        }

        public bool OrderExists(int orderId) {
            return Get(orderId) != null;
        }
    }
}