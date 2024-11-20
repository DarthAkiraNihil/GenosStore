using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GenosStore.Model.Entity.Item.Characteristic;

namespace GenosStore.Model.Entity.Item.ComputerComponent {
	[Table("public.ComputerCases")]
	public class ComputerCase: ComputerComponent {
		//public override ItemType Type => ItemType.ComputerCase;

		//public ComputerCaseTypesize Typesize { get; set; }
		public virtual ComputerCaseTypesize ComputerCaseTypesize { get; set; }
		[Required]
		public float Length { get; set; }
		[Required]
		public float Width { get; set; }
		[Required]
		public float Height { get; set; }

		[Required]
		public List<MotherboardFormFactor> SupportedMotherboardFormFactors { get; set; }
		[Required]
		public bool HasARGBLighting { get; set; }
		[Required]
		public byte DrivesSlotsCount;

		public ComputerCase() {
			SupportedMotherboardFormFactors = new List<MotherboardFormFactor>();
		}

	}
}
