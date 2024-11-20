using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using GenosStore.Model.Entity.Base;

namespace GenosStore.Model.Entity.Orders {

	[Table("public.BankSystems")]
	public class BankSystem: Named {
		[Required]
		public long Id { get; set; }
	}
	// public enum BankSystem {
	// 	Visa,
	// 	MasterCard,
	// 	UnionPay,
	// 	JBC,
	// 	Mir
	// }
}