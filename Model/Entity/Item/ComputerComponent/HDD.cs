using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenosStore.Model.Entity.Item.ComputerComponent {
	[Table("public.HDDs")]
	public class HDD: DiskDrive {
		public override ItemType Type => ItemType.HDD;

		public int RPM { get; set; }
	}
}
