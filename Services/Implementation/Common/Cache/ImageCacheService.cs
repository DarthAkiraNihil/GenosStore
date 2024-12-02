using System.Collections.Generic;
using System.Windows.Media.Imaging;
using GenosStore.Services.Interface.Common.Cache;

namespace GenosStore.Services.Implementation.Common.Cache {
    public sealed class ImageCacheService: IImageCacheService {
        private Dictionary<string, BitmapImage> _cached = new Dictionary<string, BitmapImage>();

        public BitmapImage Get(string key) {
            return _cached[key];
        }

        public void Add(string key, BitmapImage image) {
            _cached.Add(key, image);
        }

        public bool HasKey(string key) {
            return _cached.ContainsKey(key);
        }
    }
}