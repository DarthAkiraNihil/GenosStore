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
		public Customer Customer { get; set; }

		public List<OrderedItem> Items { get; set; }
		public OrderStatus Status { get; set; }
		public DateTime CreatedAt { get; set; }
	}
}
