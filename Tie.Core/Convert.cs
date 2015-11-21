using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tie.Core
{
    public class Convert
    {
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
