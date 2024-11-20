using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using GenosStore.Model.Entity.Base;

// public enum Certificate80Plus {
// 	None,
// 	Standard,
// 	Bronze,
// 	Silver,
// 	Gold,
// 	Platinum,
// 	Titanium
// }

namespace GenosStore.Model.Entity.Item.Characteristic {
	[Table("public.Certificates80Plus")]
	public class Certificate80Plus: Named {
		[Required]
		public long Id { get; set; }
	}
}