using System.Data.Entity.ModelConfiguration.Conventions;
using System.Runtime.CompilerServices;
using GenosStore.Services.Interface.Navigation.PageUrlCategories;
using GenosStore.Utility.Types.Enum;
using QuestPDF.Fluent;

namespace GenosStore.Services.Interface.Navigation {
    public interface IPageUrlResolverService {
        
        //IAdminUrlsService Admin { get; }
        //IAuthRegisterUrlsService Auth { get; }
        //IItemListUrlsService ItemList { get; }
        //IItemUrlsService Item { get; }
        //IMainUrlsService Main { get; }
        //IOrderUrlsService Order { get; }

        //string NotFound { get; }
        
        string GetUrl(PageTypeDescriptor pageType, ItemTypeDescriptor? itemType = null);
        
    }
}