using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace GenosStore.Model.Entity.Item.Characteristic {
	[Table("public.Definitions")]
	public class Definition {
		public int Id { get; set; }
		public int Width { get; set; }
		public int Height { get; set; }
	}
}
