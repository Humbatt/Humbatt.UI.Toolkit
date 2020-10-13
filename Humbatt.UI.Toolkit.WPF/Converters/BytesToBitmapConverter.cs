using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media.Imaging;

namespace Humbatt.UI.Toolkit.WPF.Converters
{
    [ValueConversion(typeof(byte[]), typeof(BitmapImage))]
    public class BytesToBitmapConverter : BaseConverter, IValueConverter
    {
        private static BitmapImage _missingImage;

        public static BitmapImage MissingImage
        {
            get
            {
                if (_missingImage == null)
                    _missingImage = new BitmapImage(new Uri(@"/Humbatt.UI.Toolkit.WPF;component/Resources/no-image-icon.png", UriKind.RelativeOrAbsolute));

                return _missingImage;
            }

        }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var bytes = value as byte[];

            if (bytes != null)
            {
                try
                {
                    using (var ms = new System.IO.MemoryStream(bytes))
                    {
                        var image = new BitmapImage();
                        image.BeginInit();
                        image.CacheOption = BitmapCacheOption.OnLoad; // here
                        image.StreamSource = ms;
                        image.EndInit();
                        return image;
                    }
                }
                catch (Exception)
                {
                    return MissingImage;

                }

            }

            return MissingImage;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
