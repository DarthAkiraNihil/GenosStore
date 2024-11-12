using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenosStore.Model.Entity.User {
	[Table("public.Administrators")]
	public class Administrator: User {

		public override UserType UserType {
			get {
				return UserType.Administrator;
			}
		}
	}
}
