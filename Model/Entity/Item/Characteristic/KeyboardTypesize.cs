// public enum KeyboardTypesize {
// 	TKL,
// 	Percent60,
// 	Full,
// 	FullPlusNumpad
// }

using System.ComponentModel.DataAnnotations.Schema;
using GenosStore.Model.Entity.Base;

namespace GenosStore.Model.Entity.Item.Characteristic {
	[Table("public.KeyboardTypesizes")]
	public class KeyboardTypesize: Named {
		public long Id { get; set; }
	}
}