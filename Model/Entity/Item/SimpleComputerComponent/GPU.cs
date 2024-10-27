using GenosStore.Model.Entity.Base;
using GenosStore.Model.Entity.Item.Characteristic;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenosStore.Model.Entity.Item.SimpleComputerComponent {
	[Table("public.GPUs")]
	public class GPU: WithModel {
		public int Id { get; set; }
		public int VendorId { get; set; }

		public virtual Vendor Vendor { get; set; }
	}
}
