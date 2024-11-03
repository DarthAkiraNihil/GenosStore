// public enum RAMType {
// 	DDR3,
// 	DDR4,
// 	DDR5,
// }

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using GenosStore.Model.Entity.Base;
using GenosStore.Model.Entity.Item.ComputerComponent;

namespace GenosStore.Model.Entity.Item.Characteristic {
	[Table("public.RAMTypes")]
	public class RAMType: Named {
		public List<Motherboard> Motherboards { get; set; }

		public RAMType() {
			Motherboards = new List<Motherboard>();
		}
	}
}