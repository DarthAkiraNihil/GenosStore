using System;
using GenosStore.Model.Entity.Item.ComputerComponent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenosStore.Model.Entity.Item {
	internal class PreparedAssembly: Item {
		public override ItemType Type => ItemType.PreparedAssembly;

		public int Id { get; set; }

		public int CPUId { get; set; } 
		public int MotherboardId { get; set; }
		public int GraphicsCardId { get; set; }
		public List<RAM> RAM { get; set; }
		public List<DiskDrive> Disks { get; set; }
		public int PowerSupplyId { get; set; }
		public int DisplayId { get; set; }
		public int ComputerCaseId { get; set; }
		public int? KeyboardId { get; set; }
		public int? MouseId { get; set; }
		public int CPUCoolerId { get; set; }

		public virtual CPU CPU { get; set; }
		public virtual Motherboard Motherboard { get; set; }
		public virtual GraphicsCard GraphicsCard { get; set; }	
		public virtual PowerSupply PowerSupply { get; set; }
		public virtual Display Display { get; set; }
		public virtual ComputerCase ComputerCase { get; }
		public virtual Keyboard Keyboard { get; set; }
		public virtual Mouse Mouse { get; set; }
		public virtual CPUCooler CPUCooler { get; set; }

		public PreparedAssembly() {
			RAM = new List<RAM>();
			Disks = new List<DiskDrive>();
		}
	}
}
