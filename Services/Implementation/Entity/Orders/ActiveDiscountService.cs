using System;
using System.Collections.Generic;
using System.Linq;
using GenosStore.Model.Entity.Orders;
using GenosStore.Model.Repository.Interface;
using GenosStore.Services.Interface.Entity.Orders;

namespace GenosStore.Services.Implementation.Entity.Orders {
    public class ActiveDiscountService: IActiveDiscountService {
        private IGenosStoreRepositories _repositories;

        public void Create(ActiveDiscount item) {
            _repositories.Orders.ActiveDiscounts.Create(item);
        }

        public ActiveDiscount Get(int id) {
            return _repositories.Orders.ActiveDiscounts.Get(id);
        }

        public List<ActiveDiscount> List() {
            return _repositories.Orders.ActiveDiscounts.List();
        }

        public void Update(ActiveDiscount item) {
            _repositories.Orders.ActiveDiscounts.Update(item);
        }

        public void Delete(int id) {
            _repositories.Orders.ActiveDiscounts.Delete(id);
        }

        public bool IsActive(ActiveDiscount activeDiscount) {
            return activeDiscount.EndsAt > DateTime.Now;
        }

        public void Deactivate(ActiveDiscount activeDiscount) {
            _ = _repositories
                        .Items
                        .All
                        .List()
                        .Where(i => i.ActiveDiscount == activeDiscount)
                        .Select(i => { i.ActiveDiscount = null; return i; })
                        .ToList()
                        .Select(i => { _repositories.Items.All.Update(i); return i; })
                        .ToList();
            _repositories.Save();
        }

        public ActiveDiscountService(IGenosStoreRepositories repositories) {
            _repositories = repositories;
        }

        public int Save() {
            return _repositories.Save();
        }
    }
}