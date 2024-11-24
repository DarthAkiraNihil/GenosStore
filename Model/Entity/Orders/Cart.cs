using GenosStore.Model.Entity.User;
using GenosStore.Model.Entity.Item;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace GenosStore.Model.Entity.Orders {

	[Table("public.Carts")]
	public class Cart {
		public int CustomerId { get; set; }
		public virtual Customer Customer { get; set; }
		public virtual List<CartItem> Items { get; set; }
		
	}
}
