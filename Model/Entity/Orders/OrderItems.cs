using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenosStore.Model.Entity.Orders {
	[Table("public.OrderedItems")]
	public class OrderItems {
		public int OrderId { get; set; }
		public int ItemId { get; set; }
		
		public int Quantity { get; set; }
		public double BoughtFor { get; set; }

		public virtual Item.Item Item { get; set; }
		public virtual Order Order { get; set; }
	}
}
