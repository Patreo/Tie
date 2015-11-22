using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Tie.Core
{
    public class Reflector
    {
        /// <summary>
        /// Gets the type.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="types">The types.</param>
        /// <returns></returns>
        public static Type[] GetType<T>(Type[] types)
        {
            List<Type> lst = new List<Type>();

            foreach (Type t in types)
            {
                if (t.BaseType == null)
                {
                    continue;
                }

                if (t.BaseType == typeof(T))
                {
                    lst.Add(t);
                }
            }

            return lst.ToArray();
        }

        /// <summary>
        /// Gets the web entry assembly.
        /// </summary>
        /// <returns></returns>
        public static Assembly GetWebEntryAssembly()
        {
            if (System.Web.HttpContext.Current == null || System.Web.HttpContext.Current.ApplicationInstance == null)
            {
                return null;
            }

            var type = System.Web.HttpContext.Current.ApplicationInstance.GetType();

            while (type != null && type.Namespace == "ASP")
            {
                type = type.BaseType;
            }

            if (type == null)
            {
                return null;
            }
            else
            {
                return type.Assembly;
            }
        }
    }
}
