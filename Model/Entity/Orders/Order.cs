using GenosStore.Model.Entity.User;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenosStore.Model.Entity.Orders {
	[Table("public.Orders")]
	public class Order {
		public long Id { get; set; }
		public int CustomerId { get; set; }
		
		public virtual Customer Customer { get; set; }

		public List<OrderItems> Items { get; set; }
		public int OrderStatusId { get; set; }
		public virtual OrderStatus Status { get; set; }
		
		public DateTime CreatedAt { get; set; }
	}
}
