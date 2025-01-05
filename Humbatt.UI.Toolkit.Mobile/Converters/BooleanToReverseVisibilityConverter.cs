using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Humbatt.UI.Toolkit.Mobile.Converters
{
    public class BooleanToReverseVisibilityConverter : BaseConverter, IValueConverter
    {
        public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            if (value == null)
                return Visibility.Visible;

            if (!(value is bool))
                return Visibility.Visible;

            var hide = Visibility.Collapsed;

            //if (parameter != null)
            //{
            //	var pString = parameter.ToString();

            //	if (pString.Equals("collapsed", StringComparison.OrdinalIgnoreCase))
            //		hide = Visibility.Collapsed;
            //}

            var bVal = (bool)value;

            return (bVal == true) ? hide : Visibility.Visible;
        }

        public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
