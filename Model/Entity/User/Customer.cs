using GenosStore.Model.Entity.Orders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenosStore.Model.Entity.User {
	public abstract class Customer: User {
		public virtual List<Order> Orders {  get; set; }
		public virtual List<BankCard> BankCards {  get; set; }
		[Required]
		public virtual Cart Cart { get; set; }

		public Customer() {
			//Orders = new List<Order>();
			//BankCards = new List<BankCard>();
		}
	}
}
