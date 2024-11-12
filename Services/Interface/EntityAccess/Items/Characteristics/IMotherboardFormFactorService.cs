using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using GenosStore.Model.Entity.Base;
using GenosStore.Model.Entity.Item.ComputerComponent;

// public enum MotherboardFormFactor {
// 	miniATX,
// 	ATX,
// 	microATX,
// 	miniITX,
// }

namespace GenosStore.Model.Entity.Item.Characteristic {
	[Table("public.MotherboardFormFactors")]
	public class MotherboardFormFactor: Named {
		public long Id { get; set; }
		public List<ComputerCase> ComputerCases { get; set; }

		public MotherboardFormFactor() {
			ComputerCases = new List<ComputerCase>();
		}

	}
}