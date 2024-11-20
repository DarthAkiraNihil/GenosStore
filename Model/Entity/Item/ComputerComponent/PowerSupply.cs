using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GenosStore.Model.Entity.Item.Characteristic;

namespace GenosStore.Model.Entity.Item.ComputerComponent {
	[Table("public.PowerSupplies")]
	public class PowerSupply: ComputerComponent {

		[Required]
		public byte SataPorts { get; set; }
		[Required]
		public byte MolexPorts { get; set; }
		[Required]
		public int PowerOutput { get; set; }
		
		public virtual Certificate80Plus Certificate80Plus { get; set; }
	}
}
