using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenosStore.Model.Entity.User {
	internal class Administrator: User {

		public override UserType UserType {
			get {
				return UserType.Administrator;
			}
		}
	}
}
