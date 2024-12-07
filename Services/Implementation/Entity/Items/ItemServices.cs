﻿using GenosStore.Services.Interface.Entity.Items;
using GenosStore.Services.Interface.Entity.Items.Characteristics;
using GenosStore.Services.Interface.Entity.Items.ComputerComponents;
using GenosStore.Services.Interface.Entity.Items.SimpleComputerComponents;

namespace GenosStore.Services.Implementation.Entity.Items {
    public class ItemServices: IItemServices {
        private readonly IComputerComponentServices _computerComponentServices;
        private readonly ICharacteristicsService _characteristicsService;
        private readonly ISimpleComputerComponentService _simpleComputerComponentService;
        private readonly IPreparedAssemblyService _preparedAssemblyService;
        private readonly IItemTypeService _itemTypeService;

        public IComputerComponentServices ComputerComponents {
            get {
                return _computerComponentServices;
            }
        }

        public ICharacteristicsService Characteristics {
            get {
                return _characteristicsService;
            }
        }

        public ISimpleComputerComponentService SimpleComputerComponents {
            get {
                return _simpleComputerComponentService;
            }
        }

        public IPreparedAssemblyService PreparedAssemblies {
            get {
                return _preparedAssemblyService;
            }
        }

        public IItemTypeService ItemTypes {
            get {
                return _itemTypeService;
            }
        }

        public ItemServices(
            IComputerComponentServices computerComponentServices,
            ICharacteristicsService characteristicsService,
            ISimpleComputerComponentService simpleComputerComponentService,
            IPreparedAssemblyService preparedAssemblyService,
            IItemTypeService itemTypeService
            ) {
            _computerComponentServices = computerComponentServices;
            _characteristicsService = characteristicsService;
            _simpleComputerComponentService = simpleComputerComponentService;
            _preparedAssemblyService = preparedAssemblyService;
            _itemTypeService = itemTypeService;
        }
        
    }
}