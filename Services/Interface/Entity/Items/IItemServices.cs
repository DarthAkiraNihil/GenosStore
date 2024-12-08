using GenosStore.Model.Entity.Item;
using GenosStore.Services.Interface.Base;
using GenosStore.Services.Interface.Common;
using GenosStore.Services.Interface.Entity.Items.Characteristics;
using GenosStore.Services.Interface.Entity.Items.ComputerComponents;
using GenosStore.Services.Interface.Entity.Items.SimpleComputerComponents;

namespace GenosStore.Services.Interface.Entity.Items {
    public interface IItemServices {
		ICharacteristicsService Characteristics { get; }
        IComputerComponentServices ComputerComponents { get; }
        ISimpleComputerComponentService SimpleComputerComponents { get; }
        IItemTypeService ItemTypes { get; }
        IPreparedAssemblyService PreparedAssemblies { get; }
    }
}