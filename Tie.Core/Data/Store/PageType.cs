using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tie.Data.Store
{
    public class PageType
    {
        public PageType()
        {

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
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the URL.
        /// </summary>
        /// <value>
        /// The URL.
        /// </value>
        public string Url
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
        public string QualifiedName 
        { 
            get;
            set; 
        }
    }
}
