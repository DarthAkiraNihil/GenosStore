using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using GenosStore.Model.Entity.Base;

// public enum CoolerMaterial {
// 	Cooper,
// 	Aluminium
// }

namespace GenosStore.Model.Entity.Item.Characteristic {
	[Table("public.CoolerMaterials")]
	public class CoolerMaterial: Named {
		[Required]
		public long Id { get; set; }
	}
}