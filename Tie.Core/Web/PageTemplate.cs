using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Web;
using Tie.Core;
using Tie.Data;

namespace Tie.Web
{
    public class PageTemplate<T> : System.Web.UI.Page where T: Tie.Web.Page
    {
        private Database m_Database;

        /// <summary>
        /// Initializes a new instance of the <see cref="PageTemplate{T}"/> class.
        /// </summary>
        public PageTemplate()
            : base()
        {
            this.m_Database = ((SqlDatabase)Tie.Data.Provider.DataProviderManager.Provider).Database;
            this.LoadThis();           
        }

        /// <summary>
        /// Gets or sets the this page.
        /// </summary>
        /// <value>
        /// The this page.
        /// </value>
        public T ThisPage
        {
            get;
            set;
        }

        /// <summary>
        /// Gets the database.
        /// </summary>
        /// <value>
        /// The database.
        /// </value>
        public Database Database
        {
            get { return this.m_Database; }
        }

        /// <summary>
        /// Loads the this.
        /// </summary>
        private void LoadThis()
        {
            string strPath = HttpContext.Current.Request.Path;

            if (strPath.StartsWith("/") == true)
            {
                strPath = strPath.Substring(1, strPath.Length - 1);
            }

            Tie.Data.Store.PageType pageType = DataStoreHelper.Instance.GetPageType(typeof(T).FullName);

            if (pageType == null)
            {
                return;
            }

            Tie.Data.Store.Page pageStore = DataStoreHelper.Instance.GetPageBySlug(pageType.ID, strPath);            
            this.ThisPage = PageFactory.BuildPage<T>(pageStore.ID);

            // Load Title and MetaTags
            this.Title = this.ThisPage.MetaTitle;
            this.MetaKeywords = this.ThisPage.MetaKeywords;
            this.MetaDescription = this.ThisPage.MetaDescription;
        }
    }
}
