using GenosStore.Model.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenosStore.Model.Entity.Orders {
	public class Discount {
		public long Id { get; set; }
		public List<Item.Item> ForItems { get; set; }

		public Discount() {
			ForItems = new List<Item.Item>();
		}
	}
}
