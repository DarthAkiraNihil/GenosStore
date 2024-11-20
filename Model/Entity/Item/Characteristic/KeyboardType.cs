using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using GenosStore.Model.Entity.Base;

// public enum KeyboardType {
// 	Optical,
// 	Mechanic,
// 	Membrane,
// }

namespace GenosStore.Model.Entity.Item.Characteristic {
	[Table("public.KeyboardType")]
	public class KeyboardType: Named {
		[Required]
		public long Id { get; set; }
	}
}