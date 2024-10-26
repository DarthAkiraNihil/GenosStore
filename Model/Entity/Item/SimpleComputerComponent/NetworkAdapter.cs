using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenosStore.Model.Entity.Item.SimpleComputerComponent {
	internal class NetworkAdapter: SimpleComputerComponent {
		public override SimpleComputerComponentType Type => SimpleComputerComponentType.NetworkAdapter;
	}
}
