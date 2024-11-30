using System.Collections.Generic;
using System.Windows.Media.Imaging;

namespace GenosStore.Services {
    public class ImageCache {
        private static Dictionary<string, BitmapImage> _cached = new Dictionary<string, BitmapImage>();

        public static BitmapImage Get(string key) {
            return _cached[key];
        }

        public static void Add(string key, BitmapImage image) {
            _cached.Add(key, image);
        }

        public static bool HasKey(string key) {
            return _cached.ContainsKey(key);
        }
    }
}