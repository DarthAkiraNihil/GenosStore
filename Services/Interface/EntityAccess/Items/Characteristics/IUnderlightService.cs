using System.ComponentModel.DataAnnotations.Schema;
using GenosStore.Model.Entity.Base;

// public enum Underlight {
// 	LED,
// 	CCFL,
// 	RGB,
// }

namespace GenosStore.Model.Entity.Item.Characteristic {
	[Table("public.Underlights")]
	public class Underlight: Named {
		public long Id { get; set; }
	}
}