using System;
using System.Windows.Data;
using GenosStore.Model.Entity.Base;

namespace GenosStore.Utility.Converters {
    public class PreparedAssemblyItemToNameConverter: IValueConverter {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture) {
            if (value == null) {
                return "[нет в сборке]";
            }

            return (value as WithModel)?.Model ?? value.ToString();
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture) {
            throw new NotImplementedException();
        }
    }
}