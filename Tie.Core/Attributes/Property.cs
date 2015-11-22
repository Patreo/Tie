using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tie.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class PropertyAttribute : Attribute
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Property"/> class.
        /// </summary>
        /// <param name="Title">The title.</param>
        public PropertyAttribute(string Title)
        {
            this.Title = Title;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PropertyAttribute"/> class.
        /// </summary>
        /// <param name="Title">The title.</param>
        /// <param name="Description">The description.</param>
        public PropertyAttribute(string Title, string Description)
            : this(Title)
        {
            this.Description = Description;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PropertyAttribute"/> class.
        /// </summary>
        /// <param name="Title">The title.</param>
        /// <param name="Description">The description.</param>
        /// <param name="Editor">The editor.</param>
        public PropertyAttribute(string Title, string Description, string Editor)
            : this(Title, Description)
        {
            this.Editor = Editor;
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
