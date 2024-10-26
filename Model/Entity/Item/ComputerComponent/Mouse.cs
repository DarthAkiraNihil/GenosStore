using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenosStore.Model.Entity.Item.ComputerComponent {
	internal class Mouse: ComputerComponent {
		public byte ButtonsCount { get; set; }
		public bool HasProgrammableButtons { get; set; }
		public List<int> DPIModes { get; set; }
		public bool isWireless { get; set; }

		public Mouse() {
			DPIModes = new List<int>();
		}
	}
}
