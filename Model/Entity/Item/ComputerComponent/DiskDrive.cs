using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenosStore.Model.Entity.Item.ComputerComponent {
	[Table("public.DiskDrives")]
	public abstract class DiskDrive: ComputerComponent {

		[Required]
		public long Capacity { get; set; }
		[Required]
		public long ReadSpeed { get; set; }
		[Required]
		public long WriteSpeed { get; set; }

		public List<PreparedAssembly> PreparedAssemblies { get; set; }

		public DiskDrive() {
			PreparedAssemblies = new List<PreparedAssembly>();
		}
	}
}
