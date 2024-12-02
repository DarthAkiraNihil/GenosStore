using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenosStore.Model.Entity.Orders {
	[Table("public.BankCards")]
	public class BankCard {
		public int Id { get; set; }
		[Required]
		public long Number { get; set; }
		[Required]
		public int BankSystemId { get; set; }
		[Required]
		public byte ValidThruMonth { get; set; }
		[Required]
		public byte ValidThruYear { get; set; }
		[Required]
		public byte CVC { get; set; }
		[Required]
		public string Owner { get; set; }
		
		public virtual BankSystem BankSystem { get; set; }
	}
}
