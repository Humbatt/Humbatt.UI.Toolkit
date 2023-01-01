using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace Humbatt.UI.Toolkit.WPF.Converters
{
    [ValueConversion(typeof(bool), typeof(Visibility))]
    public class BooleanToReverseVisibilityConverter : BaseConverter, IValueConverter
    {
        public BooleanToReverseVisibilityConverter()
        {

        }

        #region IValueConverter Members

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value == null)
                return Visibility.Visible;

            if (!(value is bool))
                return Visibility.Visible;

            var hide = Visibility.Hidden;

            if (parameter != null)
            {
                var pString = parameter.ToString();

                if (pString.Equals("collapsed", StringComparison.OrdinalIgnoreCase))
                    hide = Visibility.Collapsed;
            }

            var bVal = (bool)value;

            return (bVal == true) ? hide : Visibility.Visible;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotSupportedException();
        }

        #endregion
    }
}
