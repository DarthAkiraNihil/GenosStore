using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenosStore.Model.Entity.Item.SimpleComputerComponent {
	[Table("public.MotherboardChipsets")]
	public class MotherboardChipset: SimpleComputerComponent {
		public override SimpleComputerComponentType Type => SimpleComputerComponentType.MotherboardChipset;
	}
}
