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

namespace Humbatt.UI.Toolkit.WinUI.Converters
{

#if WPF
	[ValueConversion(typeof(bool), typeof(Visibility))]
#endif
	public class BooleanToReverseVisibilityConverter : BaseConverter, IValueConverter
	{
		public BooleanToReverseVisibilityConverter()
		{

		}

#if WINUI
		public object Convert(object value, Type targetType, object parameter, string language)
#elif WPF
		public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
#endif
		
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
