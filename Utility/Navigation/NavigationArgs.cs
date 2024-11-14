using System;
using GenosStore.Services.Interface;

namespace GenosStore.Utility.Navigation {
    public class NavigationArgs {
        
        public string URL { get; set; }
        public string Title { get; set; }
        public AbstractViewModel ViewModel { get; set; }
        public int Id { get; set; }
        
        public NavigationArgs() {}
        
    }
}