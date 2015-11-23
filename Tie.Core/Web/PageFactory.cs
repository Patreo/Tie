using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using Tie.Core;
using Tie.Data;

namespace Tie.Web
{
    public class PageFactory
    {
        /// <summary>
        /// Builds the page.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="PageID">The page identifier.</param>
        /// <returns></returns>
        public static T BuildPage<T>(int PageID)
        {
            Tie.Data.Store.Page pageStore = DataStoreHelper.Instance.GetPage(PageID);

            if (pageStore == null)
            {
                return default(T);
            }

            Tie.Data.Store.PageType pageTypeStore = DataStoreHelper.Instance.GetPageType(pageStore.PageTypeID);

            if (pageTypeStore == null)
            {
                return default(T);
            }

            object obj = Reflector.CreateObject(Reflector.GetWebEntryAssembly(), pageTypeStore.QualifiedName);

            if (obj == null)
            {
                return default(T);
            }

            LoadFields((Page)obj, pageStore.ID);
            LoadProperties((Page)obj, pageStore.ID);

            return (T)obj;
        }

        /// <summary>
        /// Loads the fields.
        /// </summary>
        /// <param name="page">The page.</param>
        /// <param name="PageID">The page identifier.</param>
        private static void LoadFields(Page page, int PageID)
        {
            // Load Title
            Tie.Data.Store.PageField field;

            field = DataStoreHelper.Instance.GetPageField(PageID, "MetaTitle");
            if (field != null)
            {
                Reflector.SetPropertyValue(page, "MetaTitle", field.Value ?? "");
            }

            field = DataStoreHelper.Instance.GetPageField(PageID, "MetaKeywords");
            if (field != null)
            {
                Reflector.SetPropertyValue(page, "MetaKeywords", field.Value ?? "");
            }

            field = DataStoreHelper.Instance.GetPageField(PageID, "MetaDescription");
            if (field != null)
            {
                Reflector.SetPropertyValue(page, "MetaDescription", field.Value ?? "");
            }
        }

        /// <summary>
        /// Loads the properties.
        /// </summary>
        /// <param name="page">The page.</param>
        /// <param name="PageID">The page identifier.</param>
        private static void LoadProperties(Page page, int PageID)
        {
            Assembly asm = Assembly.GetExecutingAssembly();

            foreach (Tie.Data.Store.PropertyType propertyType in DataStoreHelper.Instance.GetPropertyTypes(PageID))
            {
                Type t = Reflector.GetType(asm, propertyType.QualifiedName);
                if (t == null)
                {
                    continue;
                }

                object prop = Reflector.CreateObject(t);
                Reflector.SetPropertyValue(page, propertyType.Name, prop);

                Tie.Data.Store.PageProperty pageProperty = DataStoreHelper.Instance.GetPageProperty(PageID, propertyType.ID);
                if (pageProperty != null)
                {
                    Reflector.SetPropertyValue(prop, "Value", pageProperty.Content);
                }
            }
        }


    }
}
