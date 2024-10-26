using GenosStore.Model.Entity.Item.SimpleComputerComponent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenosStore.Model.Entity.Item.ComputerComponent {
	internal abstract class SSD: DiskDrive {
		public int TBW { get; set; }
		public float DWPD { get; set; }
		public byte BitsForCell { get; set; }
		public int SSDControllerId { get; set; }

		public virtual SSDController SSDController { get; set; }

	}
}
