using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenosStore.Model.Entity.Item.ComputerComponent {
	[Table("public.NVMeSSDs")]
	public class NVMeSSD: ComputerComponent {
		public override ItemType Type => ItemType.NVMeSSD;
	}
}
