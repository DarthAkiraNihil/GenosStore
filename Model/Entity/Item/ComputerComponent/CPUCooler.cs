using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenosStore.Model.Entity.Item.ComputerComponent {
	[Table("public.CPUCoolers")]
	public class CPUCooler: ComputerComponent {
		public override ItemType Type => ItemType.CPUCooler;

		public long MaxFanRPM { get; set; }
		public CoolerMaterial FoundationMaterial { get; set; }
		public CoolerMaterial RadiatorMaterial { get; set; }
		public byte TubesCount { get; set; }
		public float TubesDiameter { get; set; }
		public byte FanCount { get; set; }
	}
}
