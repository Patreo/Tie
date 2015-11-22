using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace Tie.Data.Store
{
    public class PageProperty
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PageProperty"/> class.
        /// </summary>
        public PageProperty()
        {
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
        /// Gets or sets the page identifier.
        /// </summary>
        /// <value>
        /// The page identifier.
        /// </value>
        public int PageID
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the property type identifier.
        /// </summary>
        /// <value>
        /// The property type identifier.
        /// </value>
        public int PropertyTypeID
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the language identifier.
        /// </summary>
        /// <value>
        /// The language identifier.
        /// </value>
        public int LanguageID 
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
        /// Gets or sets the content.
        /// </summary>
        /// <value>
        /// The content.
        /// </value>
        public string Content 
        { 
            get;
            set;
        }
    }
}
