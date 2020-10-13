using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace Humbatt.UI.Toolkit.WPF.Converters
{
    [ValueConversion(typeof(bool), typeof(FontWeight))]
    public class BoolToFontWeight : BaseConverter, IValueConverter
    {
        public BoolToFontWeight()
        {

        }


        /// <summary>
        /// Converts a value.
        /// </summary>
        /// <param name="value">The value produced by the binding source.</param>
        /// <param name="targetType">The type of the binding target property.</param>
        /// <param name="parameter">The converter parameter to use.</param>
        /// <param name="culture">The culture to use in the converter.</param>
        /// <returns>
        /// A converted value. If the method returns null, the valid null value is used.
        /// </returns>
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value == null || !(value is bool))
                return FontWeights.Normal;

            var nvlue = (bool)value;

            return (nvlue == true) ? FontWeights.Bold : FontWeights.Normal;

        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
