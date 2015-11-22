using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tie.Data.Store
{
    public class Language
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Language"/> class.
        /// </summary>
        public Language()
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
        /// Gets or sets the short name.
        /// </summary>
        /// <value>
        /// The short name.
        /// </value>
        public string ShortName
        {
            get;
            set;
        }
    }
}
