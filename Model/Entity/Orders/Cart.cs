using GenosStore.Model.Entity.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenosStore.Model.Entity.Orders {
	internal class Cart {
		public Customer Customer { get; set; }
		public List<Item> Items { get; set; }
	}
}
