using GenosStore.Model.Entity.User;
using GenosStore.Services.Interface;
using GenosStore.Utility.AbstractViewModels;
using GenosStore.Utility.Types;

namespace GenosStore.ViewModel.Admin {
    public class DashboardPageModel: RequiresUserViewModel {

        private DashboardInfo _dashboardInfo;

        public DashboardInfo DashboardInfo {
            get { return _dashboardInfo; }
            set {
                _dashboardInfo = value;
                NotifyPropertyChanged("DashboardInfo");
            }
        }
        
        public DashboardPageModel(IServices services, User user) : base(services, user) {
            DashboardInfo = _services.Common.Dashboard.GetDashboardInfo(_user as Administrator);

            Title = "Дэшборд";
        }
    }
}