using GenosStore.Model.Entity.Item.SimpleComputerComponent;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GenosStore.Model.Entity.Item.Characteristic;

namespace GenosStore.Model.Entity.Item.ComputerComponent {
	[Table("public.GraphicsCards")]
	public class GraphicsCard: ComputerComponent {

		public int GPUId { get; set; }
		public int VideoRAM { get; set; }
		public List<VideoPort> VideoPorts { get; set; }
		public byte MaxDisplaysSupported { get; set; }
		public byte UsedSlots { get; set; }

		public virtual GPU GPU { get; set; }

		public GraphicsCard() {
			VideoPorts = new List<VideoPort>();
		}
	}
}
