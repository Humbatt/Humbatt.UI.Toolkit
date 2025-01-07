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

#if WPF
    /// <summary>
    /// Convert a datetime object to a string
    /// </summary>
    [ValueConversion(typeof(DateTime), typeof(string))]
#endif
    public class DateToStringConverter : BaseConverter, IValueConverter
	{
		public DateToStringConverter()
		{

		}

#if WINUI
		public object Convert(object value, Type targetType, object parameter, string language)
#elif WPF
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
#endif
        {
            if (value == null || !(value is DateTime))
				return string.Empty;

			var dateValue = (DateTime)value;

			return dateValue.ToShortDateString();

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
