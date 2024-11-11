using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using GenosStore.Model.Context;
using GenosStore.Model.Entity.Item.SimpleComputerComponent;
using GenosStore.Model.Repository.Interface.Item.SimpleComputerComponent;

namespace GenosStore.Model.Repository.Implementation.PostgreSQL.Item.SimpleComputerComponent {
    public class NetworkAdapterRepositoryPostgreSQL: INetworkAdapterRepository {

        private readonly GenosStoreDatabaseContext _context;
        
        public NetworkAdapterRepositoryPostgreSQL(GenosStoreDatabaseContext context) {
            _context = context;
        }

        public List<NetworkAdapter> List() {
            return _context.NetworkAdapters.ToList();
        }

        public NetworkAdapter Get(int id) {
            return _context.NetworkAdapters.Find(id);
        }

        public void Create(NetworkAdapter networkAdapter) {
            _context.NetworkAdapters.Add(networkAdapter);
        }

        public void Update(NetworkAdapter networkAdapter) {
            _context.Entry(networkAdapter).State = EntityState.Modified;
        }

        public void Delete(int id) {
            NetworkAdapter networkAdapter = _context.NetworkAdapters.Find(id);
            if (networkAdapter != null)
                _context.NetworkAdapters.Remove(networkAdapter);
        }
        
    }
}