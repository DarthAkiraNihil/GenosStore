namespace GenosStore.Services.Interface.Entity.Users {
    public interface IUserEntitiesService {
        IAdministratorService Administrators { get; }
        ICustomerService Customers { get; }
        IIndividualEntityService IndividualEntities { get; }
        ILegalEntityService LegalEntities { get; }
        IUserService Users { get; }
    }
}