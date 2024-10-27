using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenosStore.Model.Entity.Item.ComputerComponent {
	[Table("public.Displays")]
	public class Display: ComputerComponent {
		public override ItemType Type => ItemType.Display;

		public int DefinitionId { get; set; }
		public MatrixType MatrixType { get; set; }
		public Underlight UnderlightType { get; set; }
		public int MaxUpdateFrequency { get; set; }
		public VesaSize VesaSize { get; set; }
		public double ScreedDiagonal;
	}
}
