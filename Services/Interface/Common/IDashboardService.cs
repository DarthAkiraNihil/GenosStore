using GenosStore.Model.Entity.User;
using GenosStore.Utility.Types;

namespace GenosStore.Services.Interface.Common {
    public interface IDashboardService {
        DashboardInfo GetDashboardInfo(Administrator sudo);
    }
}