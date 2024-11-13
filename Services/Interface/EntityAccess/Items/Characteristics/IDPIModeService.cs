using GenosStore.Model.Entity.Item.Characteristic;
using GenosStore.Services.Interface.Base;
using GenosStore.Utility.Operations;

namespace GenosStore.Services.Interface.EntityAccess.Items.Characteristics {
    public interface IDPIModeService {
        DPIMode GetByDPI(int dpi);
    }
}