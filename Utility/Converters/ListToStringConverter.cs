using System;
using System.Collections;
using System.Collections.Generic;
using System.Windows.Data;
using GenosStore.Model.Entity.Base;

namespace GenosStore.Utility.Converters {
    public class ListToStringConverter: IValueConverter {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            var l = (IList) value;

            if (l == null) {
                return null;
            }
            
            string result = "";

            foreach (Named e in l) {
                result += e.Name + ", ";
            }

            return result;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}