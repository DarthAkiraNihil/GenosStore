using System;
using System.Collections.Generic;
using System.Linq;
using GenosStore.Model.Entity.User;
using GenosStore.Model.Repository.Interface;
using GenosStore.Services.Interface.Entity.Users;

namespace GenosStore.Services.Implementation.Entity.Users {
    public class LegalEntitySerivice: ILegalEntityService {
        
        private readonly IGenosStoreRepositories _repositories;

        public LegalEntitySerivice(IGenosStoreRepositories repositories) {
            _repositories = repositories;
        }

        public void RevokeVerification(User sudo, LegalEntity legalEntity) {
            foreach (var bankCard in legalEntity.BankCards) {
                _repositories.Orders.BankCards.Delete(bankCard.Id);
            }
            _repositories.Orders.Carts.DeleteRaw(legalEntity.Cart);
            _repositories.Users.LegalEntities.Delete(legalEntity.Id);
            _repositories.Save();
        }

        public void Verify(User sudo, LegalEntity legalEntity) {
            legalEntity.IsVerified = true;
            _repositories.Users.LegalEntities.Update(legalEntity);
            _repositories.Save();
        }

        public List<LegalEntity> GetVerified(User sudo) {
            if (!(sudo is Administrator)) {
                throw new UnauthorizedAccessException("ACCESS DENIED!");
            }
            
            return _repositories
                   .Users
                   .LegalEntities
                   .List()
                   .Where(e => e.IsVerified)
                   .ToList();
        }

        public List<LegalEntity> GetWaitingForVerification(User sudo) {
            
            if (!(sudo is Administrator)) {
                throw new UnauthorizedAccessException("ACCESS DENIED!");
            }
            
            return _repositories
                   .Users
                   .LegalEntities
                   .List()
                   .Where(e => !e.IsVerified)
                   .ToList();
        }
    }
}