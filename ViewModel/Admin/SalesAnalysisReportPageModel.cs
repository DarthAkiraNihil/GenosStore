using GenosStore.Model.Entity.User;
using GenosStore.Services.Interface;
using GenosStore.Utility.AbstractViewModels;

namespace GenosStore.ViewModel.Admin {
    public class SalesAnalysisReportPageModel: RequiresUserViewModel {
        public SalesAnalysisReportPageModel(IServices services, User user) : base(services, user) {
        }
        
    }
}