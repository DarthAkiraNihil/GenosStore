using System.ComponentModel.DataAnnotations.Schema;
using GenosStore.Model.Entity.Base;

// public enum MatrixType {
// 	TN,
// 	IPS,
// 	VA,
// 	OLED
// }

namespace GenosStore.Model.Entity.Item.Characteristic {
	[Table("public.MatrixTypes")]
	public class MatrixType: Named {

	}
}