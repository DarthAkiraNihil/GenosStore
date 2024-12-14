using System.Windows.Controls;
using GenosStore.Utility.Navigation;

namespace GenosStore.Services.Interface.Navigation {
    public interface IPageResolverService {
        Page Resolve(NavigationArgs args);
    }
}