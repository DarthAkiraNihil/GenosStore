using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Data;
using System.Windows.Media.Imaging;
using GenosStore.Services;

namespace GenosStore.Utility.Converters {
    public class Base64ImageConverter: IValueConverter {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
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

            if (!ImageCache.HasKey(key)) {
                BitmapImage bi = new BitmapImage();

                bi.BeginInit();
                bi.StreamSource = new MemoryStream(System.Convert.FromBase64String(s));
                bi.EndInit();
                
                ImageCache.Add(key, bi);
            }
            
            return ImageCache.Get(key);
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
