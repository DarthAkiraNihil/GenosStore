using GenosStore.Model.Entity.Item.SimpleComputerComponent;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GenosStore.Model.Entity.Item.Characteristic;
using System.ComponentModel.DataAnnotations;

namespace GenosStore.Model.Entity.Item.ComputerComponent {
	[Table("public.GraphicsCards")]
	public class GraphicsCard: ComputerComponent {

		[Required]
		public int VideoRAM { get; set; }
		[Required]
		public virtual List<VideoPort> VideoPorts { get; set; }
		[Required]
		public byte MaxDisplaysSupported { get; set; }
		[Required]
		public byte UsedSlots { get; set; }

		public virtual GPU GPU { get; set; }
		
	}
}
