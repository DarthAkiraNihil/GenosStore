// public enum ItemType {
// 	CPU,
// 	RAM,
// 	Motherboard,
// 	GraphicsCard,
// 	PowerSupply,
// 	HDD,
// 	SataSSD,
// 	NVMeSSD,
// 	Display,
// 	CPUCooler,
// 	ComputerCase,
// 	Keyboard,
// 	Mouse,
// 	PreparedAssembly
// }

using System.ComponentModel.DataAnnotations.Schema;
using GenosStore.Model.Entity.Base;

namespace GenosStore.Model.Entity.Item {
	[Table("public.ItemTypes")]
	public class ItemType: Named {
		public int Id { get; set; }
	}
}
