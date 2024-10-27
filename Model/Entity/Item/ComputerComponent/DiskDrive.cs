using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenosStore.Model.Entity.Item.ComputerComponent {
	public abstract class DiskDrive: ComputerComponent {

		public long Capacity { get; set; }
		public long ReadSpeed { get; set; }
		public long WriteSpeed { get; set; }

		public List<PreparedAssembly> PreparedAssemblies { get; set; }

		public DiskDrive() {
			PreparedAssemblies = new List<PreparedAssembly>();
		}
	}
}
