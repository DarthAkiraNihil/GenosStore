using GenosStore.Services.Interface.Navigation.PageUrlCategories;
using GenosStore.Utility.Types.Enum;

namespace GenosStore.Services.Implementation.Navigation.PageUrlCategories {
    public class AuthRegisterUrlsResolverService: StandardPageUrlResolver, IAuthRegisterUrlsResolverService {
        private string Authorization => "View/AuthRegister/AuthorizationPage.xaml";
        private string RegisterIndividual => "View/AuthRegister/RegisterIndividualPage.xaml";
        private string RegisterLegal => "View/AuthRegister/RegisterLegalPage.xaml";

        public string GetUrl(PageTypeDescriptor pageType, ItemTypeDescriptor? itemType = null) {
            switch (pageType) {
                case PageTypeDescriptor.Authorization: {
                    return Authorization;
                }
                case PageTypeDescriptor.RegisterIndividual: {
                    return RegisterIndividual;
                }
                case PageTypeDescriptor.RegisterLegal: {
                    return RegisterLegal;
                }
                default: {
                    return NotFound;
                }
            }
        }
    }
}