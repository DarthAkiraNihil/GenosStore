using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GenosStore.Model.Entity.Item.Characteristic;

namespace GenosStore.Model.Entity.Item.ComputerComponent {
	[Table("public.CPUCoolers")]
	public class CPUCooler: ComputerComponent {

		public long MaxFanRPM { get; set; }
		public int FoundationMaterialId { get; set; }
		public int RadiatroMaterialId { get; set; }
		public byte TubesCount { get; set; }
		public float TubesDiameter { get; set; }
		public byte FanCount { get; set; }
		
		public virtual CoolerMaterial FoundationMaterial { get; set; }
		public virtual CoolerMaterial RadiatorMaterial { get; set; }
	}
}
