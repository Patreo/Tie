using System;
using System.Collections.Generic;
using System.Reflection;

namespace Tie.Core
{
    public static  class AttributeUtils
    {
        /// <summary>
        /// Gets the class attributes.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="type">The type.</param>
        /// <returns></returns>
        public static IList<T> GetClassAttributes<T>(Type type)
        {
            IList<T> attributeList = new List<T>();

            if (type == null)
            {
                return new List<T>();
            }

            // iterate through the attributes, retrieving the  properties
            Array.ForEach(type.GetCustomAttributes(typeof(T), false)
                , (attr) =>
                    {
                        attributeList.Add((T)attr);
                    });

            return attributeList;
        }
      
        /// <summary>
        /// Gets the attributes of the specified type applied to the class.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj">The obj.</param>
        /// <param name="attributeType">Type of the attribute.</param>
        /// <returns></returns>
        public static IList<T> GetClassAttributes<T>(object obj)
        {
            if (obj == null)  // Check
            {
                return new List<T>();
            }
            else
            {
                return AttributeUtils.GetClassAttributes<T>(obj.GetType());  
            }                    
        }

        /// <summary>
        /// Gets the class attribute.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="type">The type.</param>
        /// <returns></returns>
        public static T GetClassAttribute<T>(Type type)
        {
            IList<T> lst = GetClassAttributes<T>(type);
            return lst.Count == 0 ? default(T) : lst[0];
        }

        /// <summary>
        /// Check whether a certain attribute is associated with an object.
        /// </summary>
        /// <param name="o">The o.</param>
        /// <returns>Returns TRUE if present, FALSE if not.</returns>
        /// <typeparam name="T">The attribute to check.</typeparam>
        public static bool HasAttribute<T>(object o) where T : Attribute
        {
            return GetAttribute<T>(o, null) != null;
        }

        /// <summary>
        /// Read a certain attribute that is associated with an object.
        /// </summary>
        /// <param name="o">The object with the possible connected
        /// attribute.</param>
        /// <returns>
        /// Returns the attribute or NULL if not found.
        /// </returns>
        /// <typeparam name="T">The attribute to read.</typeparam>
        public static T GetAttribute<T>(object o) where T : Attribute
        {
            return GetAttribute<T>(o, null);
        }

        /// <summary>
        /// Read a certain attribute that is associated with an object.
        /// </summary>
        /// <param name="o">The object with the possible connected
        /// attribute.</param>
        /// <param name="fallbackValue">The value to use when not
        /// found.</param>
        /// <returns>
        /// Returns the attribute or the fallback value if not
        /// found.
        /// </returns>
        /// <typeparam name="T">The attribute to read.</typeparam>
        public static T GetAttribute<T>(object o, T fallbackValue) where T : Attribute
        {
            if (o == null)
            {
                return fallbackValue;
            }
            else
            {
                if (o is Enum)
                {
                    FieldInfo fi = ((Enum)o).GetType().GetField(o.ToString());

                    T[] attributes = (T[])fi.GetCustomAttributes(typeof(T), false);

                    if (attributes.Length > 0)
                    {
                        return attributes[0];
                    }
                    else
                    {
                        return fallbackValue;
                    }
                }
                else
                {
                    Attribute[] attributes = Attribute.GetCustomAttributes(o.GetType());

                    if (attributes == null || attributes.Length <= 0)
                    {
                        return fallbackValue;
                    }
                    else
                    {
                        foreach (Attribute attribute in attributes)
                        {
                            if (attribute is T)
                                return attribute as T;
                        }

                        return fallbackValue;
                    }
                }
            }
        }

        /// <summary>
        /// Gets the attributes.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="attributeProvider">The attribute provider.</param>
        /// <param name="inherit">if set to <c>true</c> [inherit].</param>
        /// <returns></returns>
        public static T[] GetAttributes<T>(ICustomAttributeProvider attributeProvider, bool inherit) where T : Attribute
        {
            if (attributeProvider == null)
            {
                throw new ArgumentNullException("t");
            }
            else
            {
                return (T[])attributeProvider.GetCustomAttributes(typeof(T), inherit);
            }            
        }

        /// <summary>
        /// Gets the classes.
        /// </summary>
        /// <param name="Assembly">The assembly.</param>
        /// <param name="Namespace">The namespace.</param>
        /// <returns></returns>
        public static List<string> GetClasses(Assembly Assembly, string Namespace)
        {
            List<string> namespacelist = new List<string>();
            List<string> classlist = new List<string>();

            foreach (Type type in Assembly.GetTypes())
            {
                if (type.Namespace == Namespace)
                {
                    namespacelist.Add(type.Name);
                }
            }

            foreach (string classname in namespacelist)
            {
                classlist.Add(classname);
            }

            return classlist;
        }

        /// <summary>
        /// Determines whether [is instantiatable type] [the specified t].
        /// </summary>
        /// <param name="t">The t.</param>
        /// <returns>
        /// 	<c>true</c> if [is instantiatable type] [the specified t]; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsInstantiatableType(Type t)
        {
            if (t == null)
            {
                throw new ArgumentNullException("t");
            }

            if (t.IsAbstract || t.IsInterface || t.IsArray || t.IsGenericTypeDefinition || t == typeof(void))
            {
                return false;
            }

            if (!HasDefaultConstructor(t))
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Determines whether [has default constructor] [the specified t].
        /// </summary>
        /// <param name="t">The t.</param>
        /// <returns>
        /// 	<c>true</c> if [has default constructor] [the specified t]; otherwise, <c>false</c>.
        /// </returns>
        public static bool HasDefaultConstructor(Type t)
        {
            if (t == null)
            { 
                throw new ArgumentNullException("t");
            }

            if (t.IsValueType)
            {
                return true;
            }

            return (t.GetConstructor(BindingFlags.Public | BindingFlags.Instance, null, new Type[0], null) != null);
        }
    }
}
