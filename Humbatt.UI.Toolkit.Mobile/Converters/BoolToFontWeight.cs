using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Humbatt.UI.Toolkit.Mobile.Converters
{
    public class BoolToFontWeight : BaseConverter, IValueConverter
    {
        public BoolToFontWeight()
        {

        }

        public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            if (value == null || !(value is bool))
                return FontWeights.Normal;

            var nvlue = (bool)value;

            return (nvlue == true) ? FontWeights.Bold : FontWeights.Normal;
        }

        public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
