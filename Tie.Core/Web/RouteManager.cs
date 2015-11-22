using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Routing;
using Tie.Data;

namespace Tie.Web
{
    public class RouteManager
    {
        /// <summary>
        /// Gets or sets the database.
        /// </summary>
        /// <value>
        /// The database.
        /// </value>
        public Database Database
        {
            get;
            set;
        }

        /// <summary>
        /// Routes the specified routes.
        /// </summary>
        /// <param name="routes">The routes.</param>
        public void Route(RouteCollection routes)
        {
            foreach (Tie.Data.Store.Page page in this.Database.Store.Pages.All())
            {
                Tie.Data.Store.PageType pageType = this.Database.Store.PageTypes.Get(page.PageTypeID);
                routes.MapPageRoute(page.Slug, page.Slug, pageType.Url);
            }
        }
    }
}
