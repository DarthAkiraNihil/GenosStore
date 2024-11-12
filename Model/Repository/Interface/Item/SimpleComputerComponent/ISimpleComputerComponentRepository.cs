﻿using GenosStore.Model.Entity.Item.SimpleComputerComponent;
using GenosStore.Model.Repository.Interface.Base;

namespace GenosStore.Model.Repository.Interface.Item.SimpleComputerComponent {
    public interface ISimpleComputerComponentRepository {
        // SimpleComputerComponent
        IAudioChipsetRepository AudioChipsets { get; }
        ICPUCoreRepository CPUCores { get; }
        IGPURepository GPUs { get; }
        IMotherboardChipsetRepository MotherboardChipsets { get; }
        INetworkAdapterRepository NetworkAdapters { get; }
        //ISimpleComputerComponentRepository SimpleComputerComponents { get; }
        ISimpleComputerComponentTypeRepository SimpleComputerComponentTypes { get; }
        ISSDControllerRepository SSDControllers { get; }
    }
}