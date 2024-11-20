using GenosStore.Model.Entity.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenosStore.Model.Entity.Item.Characteristic {
	[Table("public.Vendors")]
	public class Vendor: Named {
		[Required]
		public int Id { get; set; }
	}
}
