using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenosStore.Model.Entity.Orders {
	internal class OrderedItem {
		public int ItemId { get; set; }
		public double BoughtFor { get; set; }

		public ICollection<Order> Orders { get; set; }
	}
}
