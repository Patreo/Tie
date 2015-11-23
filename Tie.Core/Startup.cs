using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Routing;
using Tie.Attributes;
using Tie.Core;
using Tie.Data;
using Tie.Data.Store;
using Tie.Web;

namespace Tie
{
    public class Startup
    {
        private Database m_Database;

        /// <summary>
        /// Configurations the specified application.
        /// </summary>
        /// <param name="app">The application.</param>
        /// <exception cref="System.Exception">Web not founded.</exception>
        public void Configuration(IAppBuilder app)
        {
            Assembly asm = Reflector.GetWebEntryAssembly();

            if (asm == null)
            {
                throw new Exception("Web not founded.");
            }

            this.m_Database = ((SqlDatabase)Tie.Data.Provider.DataProviderManager.Provider).Database;
            this.KeepDatabaseUpdated();
            this.CreatePageTypes(asm);
            this.Route();
        }

        private void KeepDatabaseUpdated()
        {
            if (this.m_Database.Store.Languages.All().Count() == 0)
            {
                this.m_Database.Store.Languages.Insert(new { Name = "English", ShortName = "en" });
                this.m_Database.Store.Languages.Insert(new { Name = "Portuguese", ShortName = "pt" });
            }
        }

        /// <summary>
        /// Creates the page types.
        /// </summary>
        /// <param name="asm">The asm.</param>
        private void CreatePageTypes(Assembly asm)
        {
            int? intPageTypeID = 0;

            foreach (Type t in Reflector.GetType<Tie.Web.Page>(asm.GetExportedTypes()))
            {
                PageTypeAttribute pageTypeAttr = Tie.Core.AttributeUtils.GetClassAttributes<PageTypeAttribute>(t).FirstOrDefault();
                PageType pageType = this.m_Database.Store.PageTypes.All().Where((item) => item.Name == pageTypeAttr.Name).FirstOrDefault();

                if (pageType == null)
                {
                    intPageTypeID = this.m_Database.Store.PageTypes.Insert(new { Name = pageTypeAttr.Name, Url = pageTypeAttr.TemplateUrl, QualifiedName = t.FullName });
                }
                else
                {
                    intPageTypeID = this.m_Database.Store.PageTypes.Update(pageType.ID, new { Name = pageTypeAttr.Name, Url = pageTypeAttr.TemplateUrl, QualifiedName = t.FullName });
                }

                if (intPageTypeID != null)
                {
                    this.CreatePropertyTypes(asm, t, intPageTypeID);
                }
            }
        }

        /// <summary>
        /// Creates the property types.
        /// </summary>
        /// <param name="asm">The asm.</param>
        /// <param name="type">The type.</param>
        /// <param name="PageTypeID">The page type identifier.</param>
        private void CreatePropertyTypes(Assembly asm, Type type, int? PageTypeID)
        {
            string strEditorUrl = "";

            if (PageTypeID == null)
            {
                return;
            }

            foreach (Type t in Reflector.GetType<Tie.Web.Page>(asm.GetExportedTypes()))
            {
                foreach (PropertyInfo propertyInfo in t.GetProperties())
                {
                    foreach (PropertyAttribute attr in propertyInfo.GetCustomAttributes(typeof(PropertyAttribute), false))
                    {
                        PropertyType propertyType = this.m_Database.Store.PropertyTypes.All().Where((item) => item.PageTypeID == (int)PageTypeID && item.Name == propertyInfo.Name).FirstOrDefault();

                        if (String.IsNullOrEmpty(attr.Editor))
                        {
                            strEditorUrl = "~/Admin/PropertyTypes/" + propertyInfo.PropertyType.Name + ".ascx";
                        }
                        else
                        {
                            strEditorUrl = attr.Editor;
                        }

                        if (propertyType == null)
                        {
                            this.m_Database.Store.PropertyTypes.Insert(new { PageTypeID = (int)PageTypeID, Name = propertyInfo.Name, Title = attr.Title, Editor = strEditorUrl,  QualifiedName = propertyInfo.PropertyType.FullName });
                        }
                        else
                        {
                            this.m_Database.Store.PropertyTypes.Update(propertyType.ID, new { PageTypeID = (int)PageTypeID, Name = propertyInfo.Name, Title = attr.Title, Editor = strEditorUrl, QualifiedName = propertyInfo.PropertyType.FullName });
                        }
                    }
                }
              
            }
        }

        /// <summary>
        /// Routes this instance.
        /// </summary>
        private void Route()
        {
            RouteManager manager = new RouteManager(RouteTable.Routes);
            manager.Database = this.m_Database;
            manager.Route();
        }
    }
}