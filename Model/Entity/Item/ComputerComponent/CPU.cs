using GenosStore.Model.Entity.Item.SimpleComputerComponent;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GenosStore.Model.Entity.Item.Characteristic;

namespace GenosStore.Model.Entity.Item.ComputerComponent {
	[Table("public.CPUs")]
	public class CPU: ComputerComponent {

		//public override ItemType Type => ItemType.CPU;

		//public CPUSocket Socket { get; set; }
		public virtual CPUCore CPUCore { get; set; }
		public virtual CPUSocket CPUSocket { get; set; }

		[Required]
		public int CoresCount { get; set; }
		[Required]
		public int ThreadsCount { get; set; }
		[Required]
		public float L2CahceSize { get; set; }
		[Required]
		public float L3CacheSize { get; set; }
		[Required]
		public float TechnicalProcess {  get; set; }
		[Required]
		public float BaseFrequency { get; set; }
		[Required]
		public List<RAMType> SupportedRamType { get; set; }
		[Required]
		public int SupportedRAMSize { get; set; }
		[Required]
		public bool HasIntegratedGraphics { get; set; }

		public CPU() {
			SupportedRamType = new List<RAMType>();
		}
	}
}
