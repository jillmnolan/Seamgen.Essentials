using System;
using System.Globalization;
using Xamarin.Forms;

namespace Seamgen.Essentials.Converters
{
    /// <summary>
    /// Converts a DateTimeOffset to string
    /// </summary>
    public class DateTimeOffsetToStringConverter : IValueConverter
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
            if (value is DateTimeOffset offset && parameter is string format)
            {
                return offset.ToString(format);
            }
            else if (value is DateTimeOffset o)
            {
                return o.ToString();
            }
            else
            {
                throw new ArgumentOutOfRangeException();
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
