using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace GenosStore.Model.Entity.Item.Characteristic {
	[Table("public.Definitions")]
	public class Definition {
		public int Id { get; set; }
		[Required]
		public int Width { get; set; }
		[Required]
		public int Height { get; set; }
	}
}
