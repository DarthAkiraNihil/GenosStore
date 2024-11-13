using GenosStore.Model.Entity.Item.Characteristic;
using GenosStore.Utility.Operations;

namespace GenosStore.Services.Interface.EntityAccess.Items.Characteristics {
    public interface IDefinitionService: ISupportsGet<Certificate80Plus> {
        Definition GetStandard();
    }
}