using System;
using GenosStore.Model.Entity.User;
using GenosStore.Utility.Types.AuthRegister;

namespace GenosStore.Services.Interface.Common {
    public interface IAuthorizationService {
        Tuple<AuthorizationStatus, User> Authorize(string login, string password);
        RegistrationStatus RegisterIndividual(IndividualEntityRegistrationData regData);
        RegistrationStatus RegisterLegal(LegalEntityRegistrationData regData);
        bool CreateAdmin(string login, string password);
    }
}