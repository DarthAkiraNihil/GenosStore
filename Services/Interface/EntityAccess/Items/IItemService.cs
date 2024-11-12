using GenosStore.Model.Entity.Orders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GenosStore.Model.Entity.Base;

namespace GenosStore.Model.Entity.Item {
	[Table("public.Items")]
	public abstract class Item: WithModel {
		public int Id { get; set; }

		public double Price { get; set; }
		public string PathToImage { get; set; }
		public string Description { get; set; }
		//public abstract ItemType Type { get; }
		public int? ActiveDiscountId { get; set; }
		public int ItemTypeId { get; set; }
		
		public List<Cart> Carts { get; set; }

		public virtual ActiveDiscount ActiveDiscount { get; set; }
		public virtual ItemType ItemType { get; set; }

		public Item() {
			Carts = new List<Cart>();
		}
	}
}
