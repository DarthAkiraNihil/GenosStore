namespace GenosStore.Services.Implementation.Navigation {
    public abstract class StandardPageUrlResolver {
        protected string NotFound => "View/Other/PageNotFound.xaml";
    }
}