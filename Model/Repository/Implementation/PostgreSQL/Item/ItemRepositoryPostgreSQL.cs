using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using GenosStore.Model.Context;
using GenosStore.Model.Entity.Item.SimpleComputerComponent;
using GenosStore.Model.Repository.Implementation.PostgreSQL.Item.Characteristic;
using GenosStore.Model.Repository.Implementation.PostgreSQL.Item.ComputerComponent;
using GenosStore.Model.Repository.Implementation.PostgreSQL.Item.SimpleComputerComponent;
using GenosStore.Model.Repository.Interface.Item;
using GenosStore.Model.Repository.Interface.Item.Characteristic;
using GenosStore.Model.Repository.Interface.Item.ComputerComponent;
using GenosStore.Model.Repository.Interface.Item.SimpleComputerComponent;

namespace GenosStore.Model.Repository.Implementation.PostgreSQL.Item {
    public class ItemRepositoryPostgreSQL: IItemRepository {

        private GenosStoreDatabaseContext _context;

        private CharacteristicRepositoryPostgreSQL _characteristics;
        private ComputerComponentRepositoryPostgreSQL _computerComponents;
        private SimpleComputerComponentRepositoryPostgreSQL _simpleComputerComponents;
        private ItemTypeRepositoryPostgreSQL _itemTypes;
        private AllItemsRepositoryPostgreSQL _allItems;
        private PreparedAssemblyRepositoryPostgreSQL _preparedAssemblies;
        
        public ItemRepositoryPostgreSQL(GenosStoreDatabaseContext context) {
            _context = context;
        }
        
        public ICharacteristicRepository Characteristics {
            get {
                if (_characteristics == null) {
                    _characteristics = new CharacteristicRepositoryPostgreSQL(_context);
                }
                return _characteristics;
            }
        }
        
        public IComputerComponentRepository ComputerComponents {
            get {
                if (_computerComponents == null) {
                    _computerComponents = new ComputerComponentRepositoryPostgreSQL(_context);
                }
                return _computerComponents;
            }
        }
        
        public ISimpleComputerComponentRepository SimpleComputerComponents {
            get {
                if (_simpleComputerComponents == null) {
                    _simpleComputerComponents = new SimpleComputerComponentRepositoryPostgreSQL(_context);
                }
                return _simpleComputerComponents;
            }
        }

        public IItemTypeRepository ItemTypes {
            get {
                if (_itemTypes == null) {
                    _itemTypes = new ItemTypeRepositoryPostgreSQL(_context);
                }
                return _itemTypes;
            }
        }
        public IPreparedAssemblyRepository PreparedAssemblies {
            get {
                if (_preparedAssemblies == null) {
                    _preparedAssemblies = new PreparedAssemblyRepositoryPostgreSQL(_context);
                }
                return _preparedAssemblies;
            }
        }

        public IAllItemsRepository All {
            get {
                if (_allItems == null) {
                    _allItems = new AllItemsRepositoryPostgreSQL(_context);
                }
                return _allItems;
            }
        }

    }
}