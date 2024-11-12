using GenosStore.Model.Entity.Item.SimpleComputerComponent;
using System;
using System.Collections.Generic;
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
		public int CPUSockerId { get; set; }
		public int CoresCount { get; set; }
		public int ThreadsCount { get; set; }
		public float L2CahceSize { get; set; }
		public float L3CacheSize { get; set; }
		public float TechnicalProcess {  get; set; }
		public float BaseFrequency { get; set; }
		public List<RAMType> SupportedRamType { get; set; }
		public int SupportedRAMSize { get; set; }
		public bool HasIntegratedGraphics { get; set; }
		public int CPUCoreId {  get; set; }

		public virtual CPUCore CPUCore { get; set; }
		public virtual CPUSocket CPUSocket { get; set; }

		public CPU() {
			SupportedRamType = new List<RAMType>();
		}
	}
}
