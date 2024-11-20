using System.Collections.ObjectModel;
using GenosStore.Model.Entity.Item.Characteristic;
using GenosStore.Model.Entity.Item.ComputerComponent;
using GenosStore.Services.Interface;
using GenosStore.Utility.Types.Filtering;

namespace GenosStore.Utility.AbstractViewModels {
    public abstract class ComputerComponentListViewModel<T>: ItemListViewModel<T> where T: ComputerComponent {

        #region Properties

        public RangeItem TDP { get; set; }
        public ObservableCollection<CheckableItem<Vendor>> Vendors { get; set; }

        #endregion
        public ComputerComponentListViewModel(IServices services) : base(services) {
            TDP = new RangeItem();
        }
    }
}