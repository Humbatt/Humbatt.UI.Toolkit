#if WINUI
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml;
#elif WPF
using System.Windows;
using System.Windows.Data;
#endif
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Humbatt.UI.Toolkit.Desktop.Converters
{
	public class PercentValueConverter : BaseConverter, IValueConverter
	{
#if WINUI
		public object Convert(object value, Type targetType, object parameter, string language)
#elif WPF
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
#endif
        {
            if (value == null)
                return 0;

            double dv = (double)value;

			if (dv > 0)
				return dv / 100;

			return value;
		}

#if WINUI
		public object ConvertBack(object value, Type targetType, object parameter, string language)
#elif WPF
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
#endif
        {
            throw new NotImplementedException();
		}
	}
}
