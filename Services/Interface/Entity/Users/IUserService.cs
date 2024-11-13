using System;
using GenosStore.Model.Entity.User;
using GenosStore.Services.Interface.Base;
using GenosStore.Utility.Types.AuthRegister;

namespace GenosStore.Services.Interface.Entity.Users {
    public interface IUserService: IStandardService<User> {
		Tuple<AuthorizationStatus, User> Authorize(string login, string password);
        bool RegisterIndividual();
        bool RegisterLegal();
    }
}