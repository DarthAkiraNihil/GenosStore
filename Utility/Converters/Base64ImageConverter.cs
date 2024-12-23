﻿using System;
using System.Data;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Data;
using System.Windows.Media.Imaging;
using GenosStore.Services;
using GenosStore.Services.Interface.Common;
using GenosStore.Services.Interface.Common.Cache;
using GenosStore.Utility.Operations;

namespace GenosStore.Utility.Converters {
    public class Base64ImageConverter: IValueConverter {
        
        private static IImageCacheService _cache;

        public static void SetOnce(IImageCacheService value) {
            if (_cache != null) {
                throw new UnauthorizedAccessException("You cannot set image cache service more than once.");
            }
            _cache = value;
        }

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture) {
            string s = value as string;

            if (s == null) {
                return null;
            }
            
            var crypt = new SHA256Managed();
            var key = String.Empty;
            byte[] crypto = crypt.ComputeHash(Encoding.ASCII.GetBytes(s));
            foreach (byte theByte in crypto) {
                key += theByte.ToString("x2");
            }

            if (!_cache.HasKey(key)) {
                BitmapImage bi = new BitmapImage();

                bi.BeginInit();
                bi.StreamSource = new MemoryStream(System.Convert.FromBase64String(s));
                bi.EndInit();
                
                _cache.Add(key, bi);
            }
            
            return _cache.Get(key);
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture) {
            throw new NotImplementedException();
        }
    }
}
