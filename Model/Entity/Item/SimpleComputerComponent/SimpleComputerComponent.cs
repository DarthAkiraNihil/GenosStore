using GenosStore.Model.Entity.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenosStore.Model.Entity.Item.SimpleComputerComponent {
	[Table("public.SimpleComputerComponents")]
	public abstract class SimpleComputerComponent: WithModel {
		[Required]
		public long Id { get; set; }
		
		public virtual SimpleComputerComponentType Type { get; set; }
	}
}
