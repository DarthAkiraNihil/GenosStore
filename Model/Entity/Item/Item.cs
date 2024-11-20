using GenosStore.Model.Entity.Orders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GenosStore.Model.Entity.Base;
using System.ComponentModel.DataAnnotations;

namespace GenosStore.Model.Entity.Item {
	[Table("public.Items")]
	public abstract class Item: WithModel {
		public int Id { get; set; }

		[Required]
		public double Price { get; set; }
		
		public string ImageBase64 { get; set; }
		[Required]
		public string Description { get; set; }
		
		public List<Cart> Carts { get; set; }

		public virtual ActiveDiscount ActiveDiscount { get; set; }
		public virtual ItemType ItemType { get; set; }

		public Item() {
			Carts = new List<Cart>();
		}
	}
}
