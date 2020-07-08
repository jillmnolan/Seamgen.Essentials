using System;
using System.Globalization;
using System.IO;
using Xamarin.Forms;

namespace Seamgen.Essentials.Converters
{
    /// <summary>
    /// Convert a Base64 encoded string to an ImageSource
    /// </summary>
    public class Base64StringToImageSourceConverter : IValueConverter
    {
        /// <summary>
        /// Convert
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null && value is string base64)
            {
                var bytes = System.Convert.FromBase64String(base64);

                return ImageSource.FromStream(() => new MemoryStream(bytes));
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Convert back
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
