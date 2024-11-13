namespace GenosStore.Services.Interface.EntityAccess.Users {
    public interface IUserEntitiesService {
        IAdministratorService Administrators { get; }
        ICustomerService Customers { get; }
        IIndividualEntityService IndividualEntities { get; }
        ILegalEntityService LegalEntities { get; }
        IUserService Users { get; }
    }
}