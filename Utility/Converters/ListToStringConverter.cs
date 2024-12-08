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

            for (int i = 0; i < l.Count - 1; i++) {
                var el = l[i] as Named;
                if (el != null) {
                    result += el.Name + ", ";
                }
            }

            result += (l[l.Count - 1] as Named)?.Name;

            return result;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}