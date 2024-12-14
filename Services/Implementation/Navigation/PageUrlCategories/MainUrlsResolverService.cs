using GenosStore.Services.Interface.Navigation.PageUrlCategories;
using GenosStore.Utility.Types.Enum;

namespace GenosStore.Services.Implementation.Navigation.PageUrlCategories {
    public class MainUrlsResolverService: StandardPageUrlResolver, IMainUrlsResolverService {
        private string BankCards => "View/Main/BankCardsPage.xaml";
        private string Cart => "View/Main/CartPage.xaml";
        private string ItemCatalogue => "View/Main/ItemCataloguePage.xaml";
        private string Main => "View/Main/MainPage.xaml";

        public string GetUrl(PageTypeDescriptor pageType, ItemTypeDescriptor? itemType = null) {
            switch (pageType) {
                case PageTypeDescriptor.BankCards: {
                    return BankCards;
                }
                case PageTypeDescriptor.Cart: {
                    return Cart;
                }
                case PageTypeDescriptor.ItemCatalogue: {
                    return ItemCatalogue;
                }
                case PageTypeDescriptor.Main: {
                    return Main;
                }
                default: {
                    return NotFound;
                }
            }
        }
    }
}