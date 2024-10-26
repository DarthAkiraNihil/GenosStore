using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenosStore.Model.Entity.User {
	internal class LegalEntity: Customer {
		public override UserType UserType => UserType.LegalEntity;

		public long INN { get; set; }
		public long KPP { get; set; }
		public string PhysicalAddress { get; set; }
		public string LegalAddress { get; set; }
		public bool IsVerified { get; set; }
	}
}


