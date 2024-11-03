using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GenosStore.Model.Entity.Item.Characteristic;

namespace GenosStore.Model.Entity.Item.ComputerComponent {
	[Table("public.PowerSupplies")]
	public class PowerSupply: ComputerComponent {
		
		public byte SataPorts { get; set; }
		public byte MolexPorts { get; set; }
		public int PowerOutput { get; set; }
		public int Certiticate80PlusId { get; set; }
		
		public virtual Certiticate80Plus Certificate80Plus { get; set; }
	}
}
