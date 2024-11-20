using GenosStore.Model.Entity.User;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenosStore.Model.Entity.Orders {
	[Table("public.Orders")]
	public class Order {
		public long Id { get; set; }

		[Required]
		public virtual Customer Customer { get; set; }
		[Required]
		public List<OrderItems> Items { get; set; }
		[Required]
		public virtual OrderStatus OrderStatus { get; set; }
		[Required]
		public DateTime CreatedAt { get; set; }

		public Order() {
			Items = new List<OrderItems>();
		}
	}
}
