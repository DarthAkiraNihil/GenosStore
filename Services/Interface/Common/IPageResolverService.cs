using System.Windows.Controls;
using GenosStore.Utility.Navigation;

namespace GenosStore.Services.Interface.Common {
    public interface IPageResolverService {
        Page Resolve(NavigationArgs args);
    }
}