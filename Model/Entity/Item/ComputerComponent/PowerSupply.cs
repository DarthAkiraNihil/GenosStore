using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenosStore.Model.Entity.Item.ComputerComponent {
	[Table("public.PowerSupplies")]
	public class PowerSupply: ComputerComponent {
		public override ItemType Type => ItemType.PowerSupply;

		public byte SataPorts { get; set; }
		public byte MolexPorts { get; set; }
		public int PowerOutput { get; set; }
		public Certificate80Plus Certificate80Plus { get; set; }
	}
}
