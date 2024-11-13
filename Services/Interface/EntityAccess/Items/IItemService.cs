using GenosStore.Model.Entity.Item;
using GenosStore.Services.Interface.Base;
using GenosStore.Services.Interface.EntityAccess.Items.Characteristics;
using GenosStore.Services.Interface.EntityAccess.Items.ComputerComponents;
using GenosStore.Services.Interface.EntityAccess.Items.SimpleComputerComponents;

namespace GenosStore.Services.Interface.EntityAccess.Items {
    public interface IItemService {
		ICharacteristicsService Characteristics { get; }
        IComputerComponentService ComputerComponents { get; }
        ISimpleComputerComponentService SimpleComputerComponents { get; }
        IItemTypeService ItemTypes { get; }
        IPreparedAssemblyService PreparedAssemblies { get; }
    }
}