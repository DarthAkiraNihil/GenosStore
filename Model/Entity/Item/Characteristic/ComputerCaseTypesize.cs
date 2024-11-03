using System.ComponentModel.DataAnnotations.Schema;
using GenosStore.Model.Entity.Base;

// public enum ComputerCaseTypesize {
// 	MiniTower,
// 	MidTower,
// 	BigTower,
// }

namespace GenosStore.Model.Entity.Item.Characteristic {
	[Table("public.ComputerCaseTypesizes")]
	public class ComputerCaseTypesize: Named {
		public long Id { get; set; }
	}
}