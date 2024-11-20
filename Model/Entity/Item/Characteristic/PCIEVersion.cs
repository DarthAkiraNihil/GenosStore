using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using GenosStore.Model.Entity.Base;

// public enum PCIEVersion {
// 	V3,
// 	V4,
// }

namespace GenosStore.Model.Entity.Item.Characteristic {
	[Table("public.PCIEVersions")]
	public class PCIEVersion: Named {
		[Required]
		public long Id { get; set; }
	}
}