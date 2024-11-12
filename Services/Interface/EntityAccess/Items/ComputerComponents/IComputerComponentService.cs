using GenosStore.Model.Entity.Item.Characteristic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenosStore.Model.Entity.Item.ComputerComponent {
	public abstract class ComputerComponent: Item {
		public double TDP { get; set; }
		public int VendorId { get; set; }

		public virtual Vendor Vendor { get; set; }
	}
}
