using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using GenosStore.Model.Entity.Base;

// public enum CPUSocket {
// 	LGA1700,
// 	LGA1200,
// 	Socket4,
// }

namespace GenosStore.Model.Entity.Item.Characteristic {
	[Table("public.CPUSocket")]
	public class CPUSocket: Named {
		public long Id { get; set; }
	}
}