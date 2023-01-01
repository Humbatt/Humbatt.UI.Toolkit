using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;

namespace Humbatt.UI.Toolkit.Desktop.Converters
{
	/// <summary>
	/// Converts a hex string color to a SolidColorBrush
	/// </summary>
	/// <seealso cref="Humbatt.UI.Toolkit.WPF.Converters.BaseConverter" />
	/// <seealso cref="System.Windows.Data.IValueConverter" />
	[ValueConversion(typeof(string), typeof(SolidColorBrush))]
	public class HexStringToColorConverter : BaseConverter, IValueConverter
	{
		public HexStringToColorConverter()
		{

		}

		public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			try
			{
				if (!(value is string) || string.IsNullOrWhiteSpace((string)value))
				{
					return new SolidColorBrush(Colors.Black);
				}

				var aHexColor = (string)value;

				var aBrush = (SolidColorBrush)(new BrushConverter().ConvertFrom(aHexColor));

				return (aBrush == null) ? new SolidColorBrush(Colors.Black) : aBrush;
			}
			catch
			{
				return new SolidColorBrush(Colors.Transparent);
			}
		}

		public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			throw new NotImplementedException();
		}


	}
}
