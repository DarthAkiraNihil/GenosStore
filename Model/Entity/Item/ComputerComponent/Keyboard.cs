using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenosStore.Model.Entity.Item.ComputerComponent {
	internal class Keyboard: ComputerComponent {
		public override ItemType Type => ItemType.Keyboard;

		public KeyboardTypesize Typesize { get; set; }
		public bool HasRGBLighting { get; set; }
		public KeyboardType KeyboardType { get; set; }
		public bool IsWireless { get; set; }

	}
}
