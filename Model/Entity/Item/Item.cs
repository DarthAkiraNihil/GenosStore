using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenosStore.Model.Entity.Item {
	internal abstract class Item {
		public double Price { get; set; }
		public string PathToImage { get; set; }
		public abstract ItemType Type { get; }
	}
}
