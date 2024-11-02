using System;
using GenosStore.Model.Entity.Item.ComputerComponent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GenosStore.Model.Entity.Item {
	[Table("public.PreparedAssemblies")]
	public class PreparedAssembly: Item {
		public override ItemType Type => ItemType.PreparedAssembly;

		public int CPUId { get; set; } 
		public int MotherboardId { get; set; }
		public int GraphicsCardId { get; set; }
		public List<RAM> RAM { get; set; }
		public List<DiskDrive> Disks { get; set; }
		public int PowerSupplyId { get; set; }
		public int? DisplayId { get; set; }
		public int ComputerCaseId { get; set; }
		public int? KeyboardId { get; set; }
		public int? MouseId { get; set; }
		public int CPUCoolerId { get; set; }

		[Required]
		public virtual CPU CPU { get; set; }
		[Required]
		public virtual Motherboard Motherboard { get; set; }
		[Required]
		public virtual GraphicsCard GraphicsCard { get; set; }
		[Required]
		public virtual PowerSupply PowerSupply { get; set; }
		
		public virtual Display Display { get; set; }
		[Required]
		public virtual ComputerCase ComputerCase { get; }
		public virtual Keyboard Keyboard { get; set; }
		public virtual Mouse Mouse { get; set; }
		[Required]
		public virtual CPUCooler CPUCooler { get; set; }

		public PreparedAssembly() {
			RAM = new List<RAM>();
			Disks = new List<DiskDrive>();
		}
	}
}
