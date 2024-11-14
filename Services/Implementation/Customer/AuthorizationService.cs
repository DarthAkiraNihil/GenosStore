using System;
using System.Net;
using GenosStore.Model.Entity.User;
using GenosStore.Model.Repository.Interface;
using GenosStore.Services.Interface.Common;
using GenosStore.Utility.Types.AuthRegister;

namespace GenosStore.Services.Implementation.Customer {
    public class AuthorizationService: IAuthorizationService {
        private IGenosStoreRepositories _repositories;

        public AuthorizationService(IGenosStoreRepositories repositories) {
            _repositories = repositories;
        }

        public Tuple<AuthorizationStatus, User> Authorize(string login, string password) {
            throw new NotImplementedException();
        }

        public bool RegisterIndividual(IndividualEntityRegistrationData regData) {
            throw new NotImplementedException();
        }

        public bool RegisterLegal(LegalEntityRegistrationData regData) {
            throw new NotImplementedException();
        }
    }
}