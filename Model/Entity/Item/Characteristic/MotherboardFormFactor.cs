using System.ComponentModel.DataAnnotations.Schema;
using GenosStore.Model.Entity.Base;

// public enum MotherboardFormFactor {
// 	miniATX,
// 	ATX,
// 	microATX,
// 	miniITX,
// }

namespace GenosStore.Model.Entity.Item.Characteristic {
	[Table("public.MotherboardFormFactors")]
	public class MotherboardFormFactor: Named {

	}
}