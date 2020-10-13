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
    public class BooleanToVisibilityConverter : BaseConverter, IValueConverter
    {
        public BooleanToVisibilityConverter()
        {

        }

        #region IValueConverter Members

        public object Convert(object value, Type targetType, object parameter,
            System.Globalization.CultureInfo culture)
        {
            if (value == null)
                return Visibility.Hidden;

            if (!(value is bool))
                return Visibility.Hidden;

            var hide = Visibility.Collapsed;

            if (parameter != null)
            {
                var pString = parameter.ToString();

                if (pString.ToLower().Equals("hidden"))
                    hide = Visibility.Hidden;
            }

            var bVal = (bool)value;

            return (bVal == true) ? Visibility.Visible : hide;
        }

        public object ConvertBack(object value, Type targetType, object parameter,
            System.Globalization.CultureInfo culture)
        {
            throw new NotSupportedException();
        }

        #endregion
    }
}
