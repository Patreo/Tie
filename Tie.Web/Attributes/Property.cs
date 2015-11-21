using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tie.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class Property : Attribute
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Property"/> class.
        /// </summary>
        /// <param name="Title">The title.</param>
        public Property(string Title)
        {
            this.Title = Title;
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
    }
}
