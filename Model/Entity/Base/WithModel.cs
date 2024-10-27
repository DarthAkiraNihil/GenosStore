using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenosStore.Model.Entity.Base {
	public abstract class WithModel: Named {
		public string Model {  get; set; }
	}
}
