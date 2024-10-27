using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenosStore.Model.Entity.Item.ComputerComponent {
	[Table("public.ComputerCases")]
	public class ComputerCase: ComputerComponent {
		public override ItemType Type => ItemType.ComputerCase;

		public ComputerCaseTypesize Typesize { get; set; }
		public float Lenght { get; set; }
		public float Width { get; set; }
		public float Height { get; set; }

		public List<MotherboardFormFactor> SupportedMotherboardFormFactors { get; set; }
		public bool HasARGBLighting { get; set; }
		public byte DrivesSlotsCount;

		public ComputerCase() {
			SupportedMotherboardFormFactors = new List<MotherboardFormFactor>();
		}

	}
}
