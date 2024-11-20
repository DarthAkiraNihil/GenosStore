using GenosStore.Model.Entity.Orders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenosStore.Model.Entity.User {
	public abstract class User {
		[Required]
		public int Id { get; set; }
		[Required]
		public string Email { get; set; }
		[Required]
		public string PasswordHash { get; set; }
		[Required]
		public string Salt { get; set; }

		[Required]
		public abstract UserType UserType { get; }
	}
}
