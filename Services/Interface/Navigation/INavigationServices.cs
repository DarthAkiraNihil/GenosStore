namespace GenosStore.Services.Interface.Navigation {
    public interface INavigationServices {
        IPageResolverService PageResolver { get; }
        INavigationArgsFactory NavigationArgsFactory { get; }
    }
}