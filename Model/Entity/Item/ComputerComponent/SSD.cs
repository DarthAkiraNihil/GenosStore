using GenosStore.Model.Entity.Item.SimpleComputerComponent;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenosStore.Model.Entity.Item.ComputerComponent {
	[Table("public.SSDs")]
	public abstract class SSD: DiskDrive {
		[Required]
		public int TBW { get; set; }
		[Required]
		public float DWPD { get; set; }
		[Required]
		public byte BitsForCell { get; set; }
		
		public virtual SSDController SSDController { get; set; }

	}
}

