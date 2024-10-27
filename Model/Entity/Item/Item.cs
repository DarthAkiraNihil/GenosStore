using GenosStore.Model.Entity.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenosStore.Model.Entity.Item {
	public abstract class Item {
		public int Id { get; set; }

		public double Price { get; set; }
		public string PathToImage { get; set; }
		public string Description { get; set; }
		public abstract ItemType Type { get; }
		public int? ActiveDiscountId { get; set; }

		public virtual ActiveDiscount ActiveDiscount { get; set; }
	}
}
