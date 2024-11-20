using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenosStore.Model.Entity.Orders {
	[Table("public.ActiveDiscounts")]
	public class ActiveDiscount {
		[Required]
		public int Id { get; set; }
		[Required]
		public DateTime CreatedAt { get; set; }
		[Required]
		public DateTime EndsAt { get; set; }
		[Required]
		public double Value { get; set; }

	}
}
