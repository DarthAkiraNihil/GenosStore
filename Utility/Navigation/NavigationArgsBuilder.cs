using GenosStore.Services.Interface;

namespace GenosStore.Utility.Navigation {
    public class NavigationArgsBuilder {
        
        private NavigationArgs _args;
        
        public NavigationArgsBuilder() {
            _args = new NavigationArgs();
        }

        public NavigationArgsBuilder WithTitle(string title) {
            _args.Title = title;
            return this;
        }

        public NavigationArgsBuilder WithURL(string url) {
            _args.URL = url;
            return this;
        }

        public NavigationArgsBuilder WithViewModel(AbstractViewModel viewModel) {
            _args.ViewModel = viewModel;
            return this;
        }

        public NavigationArgsBuilder WithId(int id) {
            _args.Id = id;
            return this;
        }

        public NavigationArgs Build() {
            return _args;
        }
    }
}