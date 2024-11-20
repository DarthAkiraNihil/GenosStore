// public enum SimpleComputerComponentType {
// 	MotherboardChipset,
// 	AudioChipset,
// 	NetworkAdapter,
// 	SSDController
// }

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using GenosStore.Model.Entity.Base;

namespace GenosStore.Model.Entity.Item.SimpleComputerComponent {
	[Table("public.SimpleComputerComponentTypes")]
	public class SimpleComputerComponentType: Named {
		[Required]
		public long Id { get; set; }
	}
}