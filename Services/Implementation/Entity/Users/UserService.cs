using System.Collections.Generic;
using System.Linq;
using GenosStore.Model.Entity.User;
using GenosStore.Model.Repository.Interface;
using GenosStore.Model.Repository.Interface.User;
using GenosStore.Services.Interface.Entity.Users;

namespace GenosStore.Services.Implementation.Entity.Users {
    public class UserService: IUserService {
        
        private IGenosStoreRepositories _repositories;
        
        public UserService(IGenosStoreRepositories repositories) {
            _repositories = repositories;
        }

        public bool Exists(string email) {
            return _repositories
                   .Users
                   .Users
                   .List()
                   .Where(u => u.Email == email)
                   .Count() > 0;
        }

        public void Create(User item) {
            switch (item.UserType) {
                case UserType.IndividualEntity: {
                    _repositories
                        .Users
                        .IndividualEntities
                        .Create((IndividualEntity)item);
                    break;
                }
                    
                case UserType.LegalEntity: {
                    _repositories
                        .Users
                        .LegalEntities
                        .Create((LegalEntity)item);
                    break;
                }
                    
                case UserType.Administrator: {
                    _repositories
                        .Users
                        .Administrators
                        .Create((Administrator)item);
                    break;
                }
            }
        }

        public User FindByEmail(string email) {
            return _repositories
                         .Users
                         .Users
                         .List()
                         .Where(u => u.Email == email)
                         .FirstOrDefault();
        }
    }
}