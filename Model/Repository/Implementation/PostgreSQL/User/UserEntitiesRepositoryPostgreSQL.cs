using GenosStore.Model.Context;
using GenosStore.Model.Repository.Interface.User;

namespace GenosStore.Model.Repository.Implementation.PostgreSQL.User {
    public class UserEntitiesRepositoryPostgreSQL: IUserEntitiesRepository {
        private GenosStoreDatabaseContext _context;
        // User
        private AdministratorRepositoryPostgreSQL _administrators;
        //private CustomerRepositoryPostgreSQL _Customers;
        private IndividualEntityRepositoryPostgreSQL _individualEntities;
        private LegalEntityRepositoryPostgreSQL _legalEntities;
        private UserRepositoryPostgreSQL _users;

        public UserEntitiesRepositoryPostgreSQL(GenosStoreDatabaseContext context) {
            _context = context;
        }
        
        // User
        public IAdministratorRepository Administrators {
            get {
                if (_administrators == null) {
                    _administrators = new AdministratorRepositoryPostgreSQL(_context);
                }
                return _administrators;
            }
        }
        // public ICustomerRepository Customers {
        //     get {
        //         if (_certificates80Plus == null) {
        //             _certificates80Plus = new Certificate80PlusRepositoryPostgreSQL(_context);
        //         }
        //         return _certificates80Plus;
        //     }
        // }
        public IIndividualEntityRepository IndividualEntities {
            get {
                if (_individualEntities == null) {
                    _individualEntities = new IndividualEntityRepositoryPostgreSQL(_context);
                }
                return _individualEntities;
            }
        }
        public ILegalEntityRepository LegalEntities {
            get {
                if (_legalEntities == null) {
                    _legalEntities = new LegalEntityRepositoryPostgreSQL(_context);
                }
                return _legalEntities;
            }
        }
        public IUserRepository Users {
            get {
                if (_users == null) {
                    _users = new UserRepositoryPostgreSQL(_context);
                }
                return _users;
            }
        }
    }
}