using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Humbatt.UI.Toolkit.Mobile.Converters
{
    /// <summary>
    /// Converts a hex string color to a SolidColorBrush
    /// </summary>
    /// <seealso cref="BaseConverter" />
    /// <seealso cref="IValueConverter" />
    public class HexStringToColorConverter : BaseConverter, IValueConverter
    {
        public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            try
            {
                if (!(value is string) || string.IsNullOrWhiteSpace((string)value))
                {
                    return new SolidColorBrush(Colors.Black);
                }

                var aHexColor = (string)value;

                var aBrush = new SolidColorBrush(Color.FromArgb(aHexColor));//

                return (aBrush == null) ? new SolidColorBrush(Colors.Black) : aBrush;
            }
            catch
            {
                return new SolidColorBrush(Colors.Transparent);
            }
        }

        public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
