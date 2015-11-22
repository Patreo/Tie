using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tie.Data;

namespace Tie.Web
{
    public class PageTemplate<T> : System.Web.UI.Page
    {
        private Database m_Database;

        /// <summary>
        /// Initializes a new instance of the <see cref="PageTemplate{T}"/> class.
        /// </summary>
        public PageTemplate()
            : base()
        {
            m_Database = ((SqlDatabase)Tie.Data.Provider.DataProviderManager.Provider).Database;
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
    }
}
