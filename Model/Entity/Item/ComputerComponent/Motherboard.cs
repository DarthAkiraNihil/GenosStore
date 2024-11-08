﻿using GenosStore.Model.Entity.Item.SimpleComputerComponent;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GenosStore.Model.Entity.Item.Characteristic;

namespace GenosStore.Model.Entity.Item.ComputerComponent {
	[Table("public.Motherboards")]
	public class Motherboard: ComputerComponent {
		
		public int MotherboardFormFactorId { get; set; }
		public int CPUSocketId { get; set; }
		public int MotherboardChipsetId { get; set; }
		public List<CPUCore> SupportedCPUCores { get; set; }
		public List<RAMType> SupportedRAMTypes { get; set; }

		public byte RAMSlots { get; set; }
		public byte RAMChannels { get; set; }
		public int MaxRAMFrequency { get; set; }
		public byte PCIESlotsCount { get; set; }
		public int PCIEVersionId { get; set; }
		

		public bool HasNVMeSupport { get; set; }
		public byte M2SlotsCount { get; set; }
		public byte SataPortsCount { get; set; }
		public byte USBPortsCount { get; set; }
		public List<VideoPort> VideoPorts { get; set; }
		public byte RJ45PortsCount { get; set; }
		public byte DigiralAudioPortsCount { get; set; }

		public int AudioChipsetId { get; set; }
		public float NetworkAdapterSpeed { get; set; }
		public int NetworkAdapterId { get; set; }

		public MotherboardFormFactor FormFactor { get; set; }
		public CPUSocket CPUSocket { get; set; }
		public PCIEVersion PCIEVersion { get; set; }
		
		public virtual MotherboardChipset MotherboardChipset { get; set; }
		public virtual AudioChipset AudioChipset { get; set; }
		public virtual NetworkAdapter NetworkAdapter { get; set; }

		public Motherboard() {
			SupportedCPUCores = new List<CPUCore>();
			SupportedRAMTypes = new List<RAMType>();
			VideoPorts = new List<VideoPort>();
		}
	}
}
