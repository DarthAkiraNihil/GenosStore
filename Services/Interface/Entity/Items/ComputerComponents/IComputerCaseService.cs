using GenosStore.Model.Entity.Item.ComputerComponent;
using GenosStore.Services.Interface.Base;
using GenosStore.Utility.Operations;

namespace GenosStore.Services.Interface.Entity.Items.ComputerComponents {
    public interface IComputerCaseService:
        IStandardService<ComputerCase>,
        ISupportsFilter<ComputerCase> {
		
    }
}