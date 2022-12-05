using System;
using System.Globalization;
using System.IO;
using System.Windows.Data;
using System.Windows.Media.Imaging;

namespace GamePack.Wpf.Converters
{
    public class Base64ImageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string stringValue = value as string;

            if (stringValue == null)
            {
                return null;
            }

            var bitMapImage = new BitmapImage();

            bitMapImage.BeginInit();
            bitMapImage.StreamSource = new MemoryStream(System.Convert.FromBase64String(stringValue));
            bitMapImage.EndInit();

            return bitMapImage;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
            => throw new NotImplementedException();
    }
}
