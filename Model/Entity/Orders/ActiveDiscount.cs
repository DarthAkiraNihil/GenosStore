using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenosStore.Model.Entity.Orders {
	internal class ActiveDiscount {
		public int Id { get; set; }
		public int DiscountId { get; set; }
		public DateTime CreatedAt { get; set; }
		public DateTime EndsAt { get; set; }
		public double Value { get; set; }
	}
}
