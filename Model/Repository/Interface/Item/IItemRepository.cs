using GenosStore.Model.Repository.Interface.Base;
using GenosStore.Model.Repository.Interface.Item.Characteristic;
using GenosStore.Model.Repository.Interface.Item.ComputerComponent;
using GenosStore.Model.Repository.Interface.Item.SimpleComputerComponent;

namespace GenosStore.Model.Repository.Interface.Item {
    public interface IItemRepository {
		
        ICharacteristicRepository Characteristics { get; }
        IComputerComponentRepository ComputerComponents { get; }
        ISimpleComputerComponentRepository SimpleComputerComponents{ get; }
        IItemTypeRepository ItemTypes { get; }
        IPreparedAssemblyRepository PreparedAssemblies { get; }
        IAllItemsRepository All { get; }
        
    }
}