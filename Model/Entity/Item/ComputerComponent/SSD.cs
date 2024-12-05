using GenosStore.Model.Entity.Item.SimpleComputerComponent;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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

