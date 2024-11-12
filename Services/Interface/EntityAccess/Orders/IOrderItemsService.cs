using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenosStore.Model.Entity.Orders {
	[Table("public.OrderedItems")]
	public class OrderItems {
		//public long Id { get; set; }
		[Key]
		[Column(Order = 1)]
		public int OrderId { get; set; }
		[Key]
		[Column(Order = 2)]
		public int ItemId { get; set; }
		
		[Column(Order = 3)]
		public int Quantity { get; set; }
		[Column(Order = 4)]
		public double BoughtFor { get; set; }

		public virtual Item.Item Item { get; set; }
		public virtual Order Order { get; set; }
	}
}
