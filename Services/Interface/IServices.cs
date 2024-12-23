﻿using GenosStore.Services.Interface.Common;
using GenosStore.Services.Interface.Entity;
using GenosStore.Services.Interface.Navigation;

namespace GenosStore.Services.Interface {
    public interface IServices {
        IEntityServices Entity { get; }
        ICommonServices Common { get; }
        INavigationServices Navigation { get; }
    }
}