using System.Collections.Generic;
using System.Windows.Shapes;
using GenosStore.Model.Entity.Item.ComputerComponent;

namespace GenosStore.Model.Entity.Item.Characteristic {
    public class DPIMode {
        public int Id { get; set; }
        public int DPI { get; set; }
        
        public List<Mouse> Mouses { get; set; }

        public DPIMode() {
            Mouses = new List<Mouse>();
        }
        
    }
}