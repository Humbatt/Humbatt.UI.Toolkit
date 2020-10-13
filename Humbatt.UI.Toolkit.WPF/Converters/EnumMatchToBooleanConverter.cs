using System;
using System.Globalization;
using System.Windows.Data;

namespace Humbatt.UI.Toolkit.WPF.Converters
{
    /// <summary>
    /// Converter for switching converting between an enum and boolean for use in a Radio button group
    /// </summary>
    /// 
    public class EnumMatchToBooleanConverter : BaseConverter, IValueConverter
    {
        public EnumMatchToBooleanConverter()
        {

        }

        public object Convert(object value, Type targetType,
                             object parameter, CultureInfo culture)
        {
            if (value == null || parameter == null)
                return false;

            string checkValue = value.ToString();
            string targetValue = parameter.ToString();
            return checkValue.Equals(targetValue,
                     StringComparison.InvariantCultureIgnoreCase);
        }

        public object ConvertBack(object value, Type targetType,
                                  object parameter, CultureInfo culture)
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
