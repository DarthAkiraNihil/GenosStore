using GenosStore.Model.Entity.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenosStore.Model.Entity.Item.SimpleComputerComponent {
	public abstract class SimpleComputerComponent: WithModel {
		public long Id { get; set; }
		public abstract SimpleComputerComponentType Type { get; }
	}
}
