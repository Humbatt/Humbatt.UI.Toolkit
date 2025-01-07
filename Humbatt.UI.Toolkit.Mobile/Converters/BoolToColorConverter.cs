using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Humbatt.UI.Toolkit.Mobile.Converters
{
    public class BoolToColorConverter : BaseConverter, IValueConverter
    {
        public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            try
            {
                if (!(value is Boolean))
                {
                    return new SolidColorBrush(Colors.Transparent);
                }

                var aBool = (Boolean)value;

                if (parameter != null)
                {
                    return HandleParameters(aBool, parameter.ToString());
                }
                else
                {

                }

                return (aBool == true) ? new SolidColorBrush(Colors.LightBlue) : new SolidColorBrush(Colors.Transparent);
            }
            catch
            {
                return new SolidColorBrush(Colors.Transparent);
            }
        }

        public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        private SolidColorBrush HandleParameters(bool aBool, string parameter)
        {
            if (parameter.Contains("_"))
            {
                var colors = parameter.Split('_');

                if (colors.Length == 2)
                {
                    return (aBool == true) ? CalculateColor(colors[0]) : CalculateColor(colors[1]);
                }
                else if (colors.Length == 1)
                {
                    return (aBool == true) ? CalculateColor(colors[0]) : new SolidColorBrush(Colors.Transparent);
                }

                return new SolidColorBrush(Colors.Transparent);
            }
            else
            {
                return (aBool == true) ? CalculateColor(parameter) : new SolidColorBrush(Colors.Transparent);
            }

        }

        private SolidColorBrush CalculateColor(string color)
        {
            var theColor = Colors.Transparent;

            switch (color.ToLower())
            {
                case "blue":
                    {
                        theColor = Colors.LightBlue;
                    }
                    break;
                case "black":
                    {
                        theColor = Colors.Black;
                    }
                    break;
                case "white":
                    {
                        theColor = Colors.White;
                    }
                    break;
                case "clear":
                    {
                        theColor = Colors.Transparent;
                    }
                    break;
                case "darkgray":
                    {
                        theColor = Colors.DarkGray;
                    }
                    break;
                case "gray":
                    {
                        theColor = Colors.Gray;
                    }
                    break;
                default:
                    {
                        if (color.StartsWith("#"))
                        {
                            return new SolidColorBrush(Color.FromArgb(color));
                        };


                        if (Application.Current.Resources[color] != null)
                        {
                            return Application.Current.Resources[color] as SolidColorBrush;
                        }

                    }
                    break;
            }

            return new SolidColorBrush(theColor);
        }
    }
}
