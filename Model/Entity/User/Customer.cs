using GenosStore.Model.Entity.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenosStore.Model.Entity.User {
	internal abstract class Customer: User {
		public List<Order> Orders;
		public List<BankCard> BankCards;
		public Cart Cart { get; set; }

		public Customer() {
			Orders = new List<Order>();
			BankCards = new List<BankCard>();
		}
	}
}
