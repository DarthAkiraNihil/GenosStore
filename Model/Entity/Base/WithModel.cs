using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenosStore.Model.Entity.Base {
	public abstract class WithModel: Named {
		[Required]
		public string Model {  get; set; }
	}
}
