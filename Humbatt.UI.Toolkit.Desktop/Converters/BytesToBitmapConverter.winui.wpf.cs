#if WINUI
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Media.Imaging;
#elif WPF
using System.Windows;
using System.Windows.Data;
using System.Windows.Media.Imaging;
#endif
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;



namespace Humbatt.UI.Toolkit.Desktop.Converters
{

#if WPF
	[ValueConversion(typeof(byte[]), typeof(BitmapImage))]
#endif
    public class BytesToBitmapConverter : BaseConverter, IValueConverter
	{
		private static BitmapImage _missingImage;

		public static BitmapImage MissingImage
		{
			get
			{
				if (_missingImage == null)
					_missingImage = new BitmapImage(new Uri(@"/Humbatt.UI.Toolkit.Desktop;component/Resources/no-image-icon.png", UriKind.RelativeOrAbsolute));

				return _missingImage;
			}

		}

#if WINUI
        public object Convert(object value, Type targetType, object parameter, string language)
#elif WPF
		public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
#endif

        {
            var bytes = value as byte[];

			if (bytes != null)
			{
				try
				{
					using (var ms = new MemoryStream(bytes))
					{
						var image = new BitmapImage();
#if WINUI
						image.SetSource(ms.AsRandomAccessStream());
#elif WPF
                        image.BeginInit();
						image.CacheOption = BitmapCacheOption.OnLoad; // here
						image.StreamSource = ms;
						image.EndInit();
#endif
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
