using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenosStore.Model.Entity.User {
	internal class IndividualEntity: Customer {
		public override UserType UserType => UserType.IndividualEntity;

		public string Name { get; set; }
		public string Surname { get; set; }
		public string PhoneNumber { get; set; }
	}
}
