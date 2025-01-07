using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Humbatt.UI.Toolkit.Mobile.Converters
{
    public class BytesToBitmapConverter : BaseConverter, IValueConverter
    {
        private static ImageSource _missingImage;

        public static ImageSource MissingImage
        {
            get
            {
                if (_missingImage == null)
                    _missingImage = new FileImageSource();

                return _missingImage;
            }

        }

        public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            var bytes = value as byte[];

            if (bytes != null)
            {
                try
                {
                    using (var ms = new MemoryStream(bytes))
                    {
                        var image = ImageSource.FromStream(() => ms);

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

        public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
