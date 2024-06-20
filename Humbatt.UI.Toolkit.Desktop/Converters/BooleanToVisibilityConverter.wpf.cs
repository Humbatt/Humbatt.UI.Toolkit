﻿#if WINUI
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml;
#elif WPF
using System.Windows;
using System.Windows.Data;
#endif
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;

namespace Humbatt.UI.Toolkit.Desktop.Converters
{
	[ValueConversion(typeof(bool), typeof(Visibility))]
	public class BooleanToVisibilityConverter : BaseConverter, IValueConverter
	{
		public BooleanToVisibilityConverter()
		{

		}

		#region IValueConverter Members
#if WINUI
		public object Convert(object value, Type targetType, object parameter, string language)
#elif WPF
		public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
#endif
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

#if WINUI
		public object ConvertBack(object value, Type targetType, object parameter, string language)
#elif WPF
		public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
#endif
		{
			throw new NotSupportedException();
		}

		#endregion
	}
}
