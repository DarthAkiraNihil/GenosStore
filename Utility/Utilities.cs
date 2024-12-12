using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using GenosStore.Model.Entity.Base;
using GenosStore.Model.Entity.Item;
using GenosStore.Model.Entity.Item.Characteristic;
using GenosStore.Model.Entity.Orders;
using GenosStore.Services.Interface.Base;
using GenosStore.Services.Interface.Entity.Orders;
using GenosStore.Utility.AbstractViewModels;
using GenosStore.Utility.Types;
using GenosStore.Utility.Types.Filtering;
using GenosStore.View.Other;

namespace GenosStore.Utility {
    public class Utilities {
        public static CheckableCollection<T> ConvertToCheckableCollection<T>(List<T> list) where T: Named{
            var converted = new CheckableCollection<T>();
            foreach (var element in list) {
                converted.Add(
                    new CheckableItem<T> {Item = element, IsChecked = false}
                );
            }
            return converted;
        }

        public static void SpawnMessageBox(string title, string message) {
            var messageBox = new GenosStoreMessageBox(title, message);
            messageBox.ShowDialog();
        }
        
        public static List<string> GetNamesFromChecked<T>(CheckableCollection<T> collection) where T: Named{
            return collection
                   .Where(i => i.IsChecked)
                   .Select(i => i.Item.Name)
                   .ToList();
        }

        public static ObservableCollection<ItemListElement<T>> ConvertAndCheckDiscounts<T>(List<T> items, IStandardService<T> service) where T : Item {
            var converted = new ObservableCollection<ItemListElement<T>>();

            foreach (var item in items) {
                var discount = item.ActiveDiscount;
                var listItem = new ItemListElement<T>();
                listItem.Item = item;
                if (discount != null) {
                    
                    var now = DateTime.Now;
                    if (discount.EndsAt < now) {
                        item.ActiveDiscount = null;
                        listItem.Price = item.Price;
                        service.Update(item);
                    } else {
                        listItem.DiscountedPrice = item.Price * discount.Value;
                        listItem.OldPrice = item.Price;
                    }
                } else {
                    listItem.Price = item.Price;
                }
				
                converted.Add(listItem);
            }

            service.Save();

            return converted;
        }
        
        public static ObservableCollection<OrderDetails> ConvertOrdersToHistoryDetails(List<Model.Entity.Orders.Order> orders, IOrderService orderService) {
            var converted = new ObservableCollection<OrderDetails>();

            foreach (var order in orders) {
                var item = new OrderDetails {
                    Id = order.Id,
                    OrderTitle = $"Заказ №{order.Id}",
                    OrderCreatedAt = order.CreatedAt.ToString("dd/MM/yyyy HH:mm"),
                    OrderStatus = order.OrderStatus.Name,
                    Total = orderService.CalculateTotal(order)
                };
                converted.Add(item);
            }
            
            return converted;
        }
        
    }
}