using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenosStore.Model.Entity.Item.ComputerComponent {
	internal class RAM: ComputerComponent {
		public override ItemType Type => ItemType.RAM;

		public RAMType RAMType { get; set; }
		public int TotalSize { get; set; }
		public int ModuleSize { get; set; }
		public byte ModulesCount { get; set; }
		public int Frequency { get; set; }
		public byte CL { get; set; }
		public byte tRCD { get; set; }
		public byte tRP { get; set; }
		public byte tRAS { get; set; }
	}
}
