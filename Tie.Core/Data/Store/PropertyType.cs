using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tie.Data.Store
{
    public class PropertyType
    {
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
        public int PageTypeID
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
        /// Gets or sets the title.
        /// </summary>
        /// <value>
        /// The title.
        /// </value>
        public string Title
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>
        /// The description.
        /// </value>
        public string Description
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the name of the qualified.
        /// </summary>
        /// <value>
        /// The name of the qualified.
        /// </value>
        public string QualifiedName
        {
            get;
            set;
        }


        /// <summary>
        /// Gets or sets the editor.
        /// </summary>
        /// <value>
        /// The editor.
        /// </value>
        public string Editor
        {
            get;
            set;
        }


    }
}
