using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Humbatt.UI.Toolkit.Mobile.Converters
{
    /// <summary>
    /// Convert a datetime object to a string
    /// </summary>
    public class DateToStringConverter : BaseConverter, IValueConverter
    {
        public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            if (value == null || !(value is DateTime))
                return string.Empty;

            var dateValue = (DateTime)value;

            return dateValue.ToShortDateString();
        }

        public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
