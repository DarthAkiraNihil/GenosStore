using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenosStore.Model.Entity.Orders {
	[Table("public.OrderedItems")]
	public class OrderedItem {
		public int Id { get; set; }
		public int ItemId { get; set; }
		public double BoughtFor { get; set; }

		public ICollection<Order> Orders { get; set; }
	}
}
