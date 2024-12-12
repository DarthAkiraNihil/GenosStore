using GenosStore.Services.Interface.Entity.Users;

namespace GenosStore.Services.Implementation.Entity.Users {
    public class UserEntitiesService: IUserEntitiesService {
        private readonly ILegalEntityService _legalEntityService;

        public UserEntitiesService(ILegalEntityService legalEntityService) {
            _legalEntityService = legalEntityService;
        }

        public ILegalEntityService LegalEntities => _legalEntityService;
    }
}