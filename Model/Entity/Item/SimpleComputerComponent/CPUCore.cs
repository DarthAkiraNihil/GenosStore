﻿using GenosStore.Model.Entity.Base;
using GenosStore.Model.Entity.Item.Characteristic;
using GenosStore.Model.Entity.Item.ComputerComponent;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenosStore.Model.Entity.Item.SimpleComputerComponent {
	[Table("public.CPUCores")]
	public class CPUCore: Named {
		[Required]
		public int Id { get; set; }
		
		public virtual Vendor Vendor { get; set; }
	
		public virtual List<Motherboard> Motherboards { get; set; }

		public CPUCore() {
			//Motherboards = new List<Motherboard>();
		}
	}
}
