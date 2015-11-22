using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tie.Data.Store
{
    public class Page
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Page"/> class.
        /// </summary>
        public Page()
        {           
            this.VisibleInMenu = true;
            this.VisibleInSitemap = true;
            this.SortOrder = 1;            
            this.CreatedDate = DateTime.Now;
            this.UpdatedDate = DateTime.Now;
            this.StartPublish = DateTime.Now;
            this.Version = 1;
        }

        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public int ID
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the parent identifier.
        /// </summary>
        /// <value>
        /// The parent identifier.
        /// </value>
        public int? ParentID
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the slug.
        /// </summary>
        /// <value>
        /// The slug.
        /// </value>
        public string Slug
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the created date.
        /// </summary>
        /// <value>
        /// The created date.
        /// </value>
        public DateTime CreatedDate
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the updated date.
        /// </summary>
        /// <value>
        /// The updated date.
        /// </value>
        public DateTime UpdatedDate
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the start publish.
        /// </summary>
        /// <value>
        /// The start publish.
        /// </value>
        public DateTime StartPublish
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the end publish.
        /// </summary>
        /// <value>
        /// The end publish.
        /// </value>
        public DateTime? EndPublish
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the sort order.
        /// </summary>
        /// <value>
        /// The sort order.
        /// </value>
        public int SortOrder
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets a value indicating whether [visible in menu].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [visible in menu]; otherwise, <c>false</c>.
        /// </value>
        public bool VisibleInMenu
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets a value indicating whether [visible in sitemap].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [visible in sitemap]; otherwise, <c>false</c>.
        /// </value>
        public bool VisibleInSitemap
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the version.
        /// </summary>
        /// <value>
        /// The version.
        /// </value>
        public int Version
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the type of the page.
        /// </summary>
        /// <value>
        /// The type of the page.
        /// </value>
        public int PageTypeID
        {
            get;
            set;
        }

    }
}
