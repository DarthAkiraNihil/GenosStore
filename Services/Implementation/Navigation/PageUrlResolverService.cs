using GenosStore.Services.Interface.Navigation;
using GenosStore.Services.Interface.Navigation.PageUrlCategories;
using GenosStore.Utility.Types.Enum;

namespace GenosStore.Services.Implementation.Navigation {
    public class PageUrlResolverService: StandardPageUrlResolver, IPageUrlResolverService {

        private readonly IAdminUrlsResolverService _admin;
        private readonly IAuthRegisterUrlsResolverService _auth;
        private readonly IItemListUrlsResolverService _itemList;
        private readonly IItemUrlsResolverService _item;
        private readonly IMainUrlsResolverService _main;
        private readonly IOrderUrlsResolverService _order;

        public IAdminUrlsResolverService Admin => _admin;
        public IAuthRegisterUrlsResolverService Auth => _auth;
        public IItemListUrlsResolverService ItemList => _itemList;
        public IItemUrlsResolverService Item => _item; 
        public IMainUrlsResolverService Main => _main;
        public IOrderUrlsResolverService Order => _order;

        public PageUrlResolverService(
            IAdminUrlsResolverService admin,
            IAuthRegisterUrlsResolverService auth,
            IItemListUrlsResolverService itemList,
            IItemUrlsResolverService item,
            IMainUrlsResolverService main,
            IOrderUrlsResolverService order) {
            _admin = admin;
            _auth = auth;
            _itemList = itemList;
            _item = item;
            _main = main;
            _order = order;
        }

        public string GetUrl(PageTypeDescriptor pageType, ItemTypeDescriptor? itemType = null) {
            if (
                pageType == PageTypeDescriptor.Dashboard
            ||  pageType == PageTypeDescriptor.LegalEntityVerification
            ||  pageType == PageTypeDescriptor.OrderManagement
            ||  pageType == PageTypeDescriptor.SingleOrderManagement
            ||  pageType == PageTypeDescriptor.SalesAnalysisReport
            ||  pageType == PageTypeDescriptor.DiscountManagement
            ) {
                return _admin.GetUrl(pageType);
            }
            
            if (
                pageType == PageTypeDescriptor.Authorization
            ||  pageType == PageTypeDescriptor.RegisterIndividual
            ||  pageType == PageTypeDescriptor.RegisterLegal
            ) {
                return _auth.GetUrl(pageType);
            }
            
            if (
                pageType == PageTypeDescriptor.ItemList
            ) {
                return _itemList.GetUrl(pageType, itemType);
            }
            
            if (
                pageType == PageTypeDescriptor.ItemPage
            ) {
                return _item.GetUrl(pageType, itemType);
            }
            
            if (
                pageType == PageTypeDescriptor.BankCards
            ||  pageType == PageTypeDescriptor.Cart
            ||  pageType == PageTypeDescriptor.ItemCatalogue
            ||  pageType == PageTypeDescriptor.Main
            ) {
                return _main.GetUrl(pageType);
            }
            
            if (
                pageType == PageTypeDescriptor.OrderHistory
            ||  pageType == PageTypeDescriptor.Order
            ||  pageType == PageTypeDescriptor.Payment
            ||  pageType == PageTypeDescriptor.SuccessfulPayment
            ) {
                return _order.GetUrl(pageType);
            }

            return NotFound;
        }
    }
}