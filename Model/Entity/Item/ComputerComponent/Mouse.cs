using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenosStore.Model.Entity.Item.ComputerComponent {
	[Table("public.Mouses")]
	public class Mouse: ComputerComponent {

		public override ItemType Type => ItemType.Mouse;

		public byte ButtonsCount { get; set; }
		public bool HasProgrammableButtons { get; set; }
		public List<int> DPIModes { get; set; }
		public bool isWireless { get; set; }

		public Mouse() {
			DPIModes = new List<int>();
		}
	}
}
