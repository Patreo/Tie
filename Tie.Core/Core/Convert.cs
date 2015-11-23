using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tie.Core
{
    public class Convert
    {
        /// <summary>
        /// Determines whether this instance [can change type] the specified value.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="targetType">Type of the target.</param>
        /// <returns>
        ///   <c>true</c> if this instance [can change type] the specified value; otherwise, <c>false</c>.
        /// </returns>
        public static bool CanChangeType(object value, Type targetType)
        {
            try
            {
                System.Convert.ChangeType(value, targetType);
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// To the t.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="o">The o.</param>
        /// <param name="fallbackTo">The fallback to.</param>
        /// <returns></returns>
        public static T ToT<T>(object o, T fallbackTo)
        {
            if (o == null)
            {
                return fallbackTo;
            }

            if (typeof(T).IsEnum)
            {
                if (Enum.IsDefined(typeof(T), o))
                {
                    return (T)Enum.Parse(typeof(T), o.ToString(), true);
                }
                else
                {
                    return fallbackTo;
                }
            }

            try
            {
                if (o.GetType() == typeof(T))
                {
                    return (T)o;
                }
                else
                {
                    return (T)System.Convert.ChangeType(o, typeof(T));
                }
            }
            catch
            {
                return fallbackTo;
            }

        }
    }
}
