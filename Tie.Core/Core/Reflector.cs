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
        /// Creates the object.
        /// </summary>
        /// <param name="assemblyName">Name of the assembly.</param>
        /// <param name="className">Name of the class.</param>
        /// <returns></returns>
        public static object CreateObject(Assembly asm, string className)
        {
            return asm.CreateInstance(className, true);
        }

        /// <summary>
        /// Creates the object.
        /// </summary>
        /// <param name="className">Name of the class.</param>
        /// <returns></returns>
        public static object CreateObject(string className)
        {
            return Reflector.GetWebEntryAssembly().CreateInstance(className, true);
        }

        /// <summary>
        /// Creates the object.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <returns></returns>
        public static object CreateObject(Type type)
        {
            return type.Assembly.CreateInstance(type.FullName, true);
        }

        /// <summary>
        /// Gets the type of the property.
        /// </summary>
        /// <param name="propertyType">Type of the property.</param>
        /// <returns></returns>
        public static Type GetPropertyType(Type propertyType)
        {
            Type type = propertyType;

            if (type.IsGenericType && (type.GetGenericTypeDefinition() == typeof(Nullable)))
            {
                return type.GetGenericArguments()[0];
            }
            else
            {
                return type;
            }
        }

        /// <summary>
        /// Sets the property value.
        /// </summary>
        /// <param name="target">The target.</param>
        /// <param name="propertyName">Name of the property.</param>
        /// <param name="value">The value.</param>
        public static void SetPropertyValue(object target, string propertyName, object value)
        {
            PropertyInfo propertyInfo = target.GetType().GetProperty(propertyName);

            if (value == null)
            {
                propertyInfo.SetValue(target, value, null);
            }
            else
            {
                Type pType = GetPropertyType(propertyInfo.PropertyType);
                Type vType = GetPropertyType(value.GetType());


                if (pType.Equals(vType))
                {
                    propertyInfo.SetValue(target, value, null);
                }
                else
                {
                    if (pType.Equals(typeof(Guid)))
                    {
                        propertyInfo.SetValue(target, new Guid(value.ToString()), null);
                    }
                    else if (pType.IsEnum && vType.Equals(typeof(string)))
                    {
                        propertyInfo.SetValue(target, Enum.Parse(pType, value.ToString()), null);
                    }
                    else
                    {
                        if (pType.Equals(typeof(string)) || value == null)
                        {
                            propertyInfo.SetValue(target, System.Convert.ChangeType("", pType), null);
                        }
                        else if (pType.Equals(typeof(int)) || value == null)
                        {
                            propertyInfo.SetValue(target, System.Convert.ChangeType(0, pType), null);
                        }
                        else if (pType.Equals(typeof(bool)) || value == null)
                        {
                            propertyInfo.SetValue(target, System.Convert.ChangeType(false, pType), null);
                        }
                        else if (pType.Equals(typeof(DateTime)) || value == null)
                        {
                            propertyInfo.SetValue(target, System.Convert.ChangeType(DateTime.Now, pType), null);
                        }
                        else
                        {
                            try
                            {
                                propertyInfo.SetValue(target, System.Convert.ChangeType(value, pType), null);
                            }
                            catch { }
                        }
                    }

                }
            }
        }

        /// <summary>
        /// Gets the type.
        /// </summary>
        /// <param name="assembly">The assembly.</param>
        /// <param name="className">Name of the class.</param>
        /// <returns></returns>
        public static Type GetType(Assembly assembly, string className)
        {
            foreach (Type t in assembly.GetTypes())
            {
                if (t.FullName == className)
                {
                    return t;
                }
            }

            return null;
        }

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
