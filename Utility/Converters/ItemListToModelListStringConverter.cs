using System;
using System.Collections;
using System.Windows.Data;
using GenosStore.Model.Entity.Base;

namespace GenosStore.Utility.Converters {
    public class ItemListToModelListStringConverter: IValueConverter {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            var l = (IList) value;

            if (l == null) {
                return null;
            }
            
            string result = "";

            foreach (WithModel e in l) {
                result += e.Model + ", ";
            }

            return result;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}