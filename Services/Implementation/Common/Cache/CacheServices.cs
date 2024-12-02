using GenosStore.Services.Interface.Common.Cache;

namespace GenosStore.Services.Implementation.Common.Cache {
    public class CacheServices: ICacheServices {
        private readonly IImageCacheService _imageCacheService;

        public CacheServices(IImageCacheService imageCacheService) {
            _imageCacheService = imageCacheService;
        }

        public IImageCacheService Images {
            get { return _imageCacheService; }
        }
    }
}