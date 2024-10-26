using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenosStore.Model.Entity.Item.ComputerComponent {
	internal class HDD: DiskDrive {
		public override ItemType Type => ItemType.HDD;

		public int RPM { get; set; }
	}
}
