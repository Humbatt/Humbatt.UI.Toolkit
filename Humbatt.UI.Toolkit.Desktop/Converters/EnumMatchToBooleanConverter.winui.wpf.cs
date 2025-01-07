#if WINUI
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml;
#elif WPF
using System.Windows;
using System.Windows.Data;
#endif
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Humbatt.UI.Toolkit.Desktop.Converters
{
	/// <summary>
	/// Converter for switching converting between an enum and boolean for use in a Radio button group
	/// </summary>
	public class EnumMatchToBooleanConverter : BaseConverter, IValueConverter
	{
		public EnumMatchToBooleanConverter()
		{

		}

#if WINUI
		public object Convert(object value, Type targetType, object parameter, string language)
#elif WPF
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
#endif
		{
			if (value == null || parameter == null)
				return false;

			string checkValue = value.ToString();
			string targetValue = parameter.ToString();
			return checkValue.Equals(targetValue,
					 StringComparison.InvariantCultureIgnoreCase);
		}

#if WINUI
		public object ConvertBack(object value, Type targetType, object parameter, string language)
#elif WPF
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
#endif
        {
            if (value == null || parameter == null)
				return null;

			bool useValue = (bool)value;
			string targetValue = parameter.ToString();
			if (useValue)
				return Enum.Parse(targetType, targetValue);

			return null;
		}
	}
}
