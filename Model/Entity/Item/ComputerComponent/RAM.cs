using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GenosStore.Model.Entity.Item.Characteristic;

namespace GenosStore.Model.Entity.Item.ComputerComponent {
	[Table("public.RAMs")]
	public class RAM: ComputerComponent {

		[Required]
		public int TotalSize { get; set; }
		[Required]
		public int ModuleSize { get; set; }
		[Required]
		public byte ModulesCount { get; set; }
		[Required]
		public int Frequency { get; set; }
		[Required]
		public byte CL { get; set; }
		[Required]
		public byte tRCD { get; set; }
		[Required]
		public byte tRP { get; set; }
		[Required]
		public byte tRAS { get; set; }
		
		public virtual RAMType RAMType { get; set; }

		public List<PreparedAssembly> PreparedAssemblies { get; set; }

		public RAM() {
			PreparedAssemblies = new List<PreparedAssembly>();
		} 
	}
}
