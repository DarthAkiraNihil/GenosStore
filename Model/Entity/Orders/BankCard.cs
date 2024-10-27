using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenosStore.Model.Entity.Orders {
	[Table("public.BankCards")]
	public class BankCard {
		public int Id { get; set; }
		public long Number { get; set; }
		public BankSystem BankSystem { get; protected set; }
		public byte ValidThruMonth { get; set; }
		public byte ValidThruYear { get; set; }
		public byte CVC { get; set; }
		public string Owner { get; set; }
	}
}
