namespace GenosStore.Model.Repository.Interface.User {
    public interface IUserEntitiesRepository {
        // User
        IAdministratorRepository Administrators { get; }
        //ICustomerRepository Customers { get; }
        IIndividualEntityRepository IndividualEntities { get; }
        ILegalEntityRepository LegalEntities { get; }
        IUserRepository Users { get; }
    }
}