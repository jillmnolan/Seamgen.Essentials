using System;
using System.Collections;
using System.Linq;
using System.Globalization;
using Xamarin.Forms;

namespace Seamgen.Essentials.Converters
{
    /// <summary>
    /// Converts IEnumerable to Bool
    /// </summary>
    public class IEnumerableBoolConverter : IValueConverter
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns>Returns <c>true</c>, if the element count is higher than 0</returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var inverse = false;

            if (parameter is bool @bool)
            {
                inverse = @bool;
            }

            if (value is IList list && list != null)
            {
                return inverse ? list.Count == 0 : list.Count > 0;
            }
            else if (value is IEnumerable enumerable && enumerable != null)
            {
#pragma warning disable IDE0059 // Unnecessary assignment of a value
                foreach (var e in enumerable)
#pragma warning restore IDE0059 // Unnecessary assignment of a value
                {
                    return inverse;
                }
            }
            return !inverse;
        }

        /// <summary>
        /// throws <c>NotImplementedException</c>
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
