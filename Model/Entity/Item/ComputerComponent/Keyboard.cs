using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenosStore.Model.Entity.Item.ComputerComponent {
	[Table("public.Keyboards")]
	public class Keyboard: ComputerComponent {
		public override ItemType Type => ItemType.Keyboard;

		public KeyboardTypesize Typesize { get; set; }
		public bool HasRGBLighting { get; set; }
		public KeyboardType KeyboardType { get; set; }
		public bool IsWireless { get; set; }

	}
}
