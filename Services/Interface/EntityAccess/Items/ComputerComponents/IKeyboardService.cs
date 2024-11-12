using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GenosStore.Model.Entity.Item.Characteristic;

namespace GenosStore.Model.Entity.Item.ComputerComponent {
	[Table("public.Keyboards")]
	public class Keyboard: ComputerComponent {
		
		public int KeyboardTypesizeId { get; set; }
		public bool HasRGBLighting { get; set; }
		public int KeyboardTypeId { get; set; }
		public bool IsWireless { get; set; }
		
		public KeyboardTypesize Typesize { get; set; }
		public KeyboardType KeyboardType { get; set; }

	}
}
