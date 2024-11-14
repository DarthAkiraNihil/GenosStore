using System;
using GenosStore.Model.Entity.User;
using GenosStore.Utility.Types.AuthRegister;

namespace GenosStore.Services.Interface.Common {
    public interface IAuthorizationService {
        Tuple<AuthorizationStatus, User> Authorize(string login, string password);
        bool RegisterIndividual(IndividualEntityRegistrationData regData);
        bool RegisterLegal(LegalEntityRegistrationData regData);
    }
}