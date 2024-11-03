// public enum VideoPort {
// 	HDMI,
// 	DisplayPort,
// 	VGA,
// 	DVI,
// }

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using GenosStore.Model.Entity.Base;
using GenosStore.Model.Entity.Item.ComputerComponent;

namespace GenosStore.Model.Entity.Item.Characteristic {
	[Table("public.VideoPorts")]
	public class VideoPort: Named {
		
		public List<GraphicsCard> GraphicsCards { get; set; }
		public List<Motherboard> Motherboards { get; set; }

		public VideoPort() {
			GraphicsCards = new List<GraphicsCard>();
			Motherboards = new List<Motherboard>();
		}

	}
}