using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tie.Data;

namespace Tie.Web
{
    public class Page
    {
        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        /// <value>
        /// The title.
        /// </value>
        public string MetaTitle
        {
            get;
            set; 
        }

        /// <summary>
        /// Gets or sets the meta keywords.
        /// </summary>
        /// <value>
        /// The meta keywords.
        /// </value>
        public string MetaKeywords 
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the meta description.
        /// </summary>
        /// <value>
        /// The meta description.
        /// </value>
        public string MetaDescription 
        { 
            get; 
            set; 
        }
    }
}
