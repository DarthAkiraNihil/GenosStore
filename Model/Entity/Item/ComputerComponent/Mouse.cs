using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GenosStore.Model.Entity.Item.Characteristic;

namespace GenosStore.Model.Entity.Item.ComputerComponent {
	[Table("public.Mouses")]
	public class Mouse: ComputerComponent {

		[Required]
		public byte ButtonsCount { get; set; }
		[Required]
		public bool HasProgrammableButtons { get; set; }
		[Required]
		public List<DPIMode> DPIModes { get; set; }
		[Required]
		public bool IsWireless { get; set; }

		public Mouse() {
			DPIModes = new List<DPIMode>();
		}
	}
}
