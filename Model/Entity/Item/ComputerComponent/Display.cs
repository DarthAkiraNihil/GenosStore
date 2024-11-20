using System;
using GenosStore.Model.Entity.Item.Characteristic;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace GenosStore.Model.Entity.Item.ComputerComponent {
	[Table("public.Displays")]
	public class Display: ComputerComponent {

		[Required]
		public int MaxUpdateFrequency { get; set; }
		[Required]
		public double ScreedDiagonal;

		public virtual Definition Definition { get; set; }
		public virtual MatrixType MatrixType { get; set; }
		public virtual Underlight Underlight { get; set; }
		public virtual VesaSize VesaSize { get; set; }
	}
}
