using System;
using GenosStore.Model.Entity.Item.Characteristic;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenosStore.Model.Entity.Item.ComputerComponent {
	[Table("public.Displays")]
	public class Display: ComputerComponent {
		
		public int DefinitionId { get; set; }
		public int MatrixTypeId { get; set; }
		public int UnderlightId { get; set; }
		public int VesaSizeId { get; set; }
		public int MaxUpdateFrequency { get; set; }
		
		public double ScreedDiagonal;

		public virtual Definition Definition { get; set; }
		public virtual MatrixType MatrixType { get; set; }
		public virtual Underlight UnderlightType { get; set; }
		public virtual VesaSize VesaSize { get; set; }
	}
}
