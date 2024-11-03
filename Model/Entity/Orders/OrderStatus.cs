using System.ComponentModel.DataAnnotations.Schema;
using GenosStore.Model.Entity.Base;

// public enum OrderStatus {
// 	Created,
// 	Confirmed,
// 	AwaitsPayment,
// 	Paid,
// 	Processing,
// 	Delivering,
// 	Recieved,
// 	Canceled
// }

namespace GenosStore.Model.Entity.Orders {

	[Table("public.OrderStatus")]
	public class OrderStatus: Named {
		
	}
}