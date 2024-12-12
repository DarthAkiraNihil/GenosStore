using System.Collections.Generic;
using GenosStore.Model.Entity.User;
using GenosStore.Services.Interface.Base;

namespace GenosStore.Services.Interface.Entity.Users {
    public interface ILegalEntityService { 
        void RevokeVerification(User sudo, LegalEntity legalEntity);
        void Verify(User sudo, LegalEntity legalEntity);
        List<LegalEntity> GetVerified(User sudo);
        List<LegalEntity> GetWaitingForVerification(User sudo);
    }
}