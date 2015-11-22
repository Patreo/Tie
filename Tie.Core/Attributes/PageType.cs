using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tie.Attributes
{
    [AttributeUsage(AttributeTargets.Class)]
    public class PageTypeAttribute : Attribute
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PageType" /> class.
        /// </summary>
        /// <param name="Name">The name.</param>
        /// <param name="Title">The title.</param>
        /// <param name="TemplateUrl">The template URL.</param>
        public PageTypeAttribute(string Name, string Title, string TemplateUrl)
        {
            this.Name = Name;
            this.Title = Title;
            this.TemplateUrl = TemplateUrl;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PageType" /> class.
        /// </summary>
        /// <param name="Name">The name.</param>
        /// <param name="Title">The title.</param>
        /// <param name="TemplateUrl">The template URL.</param>
        /// <param name="Description">The description.</param>
        public PageTypeAttribute(string Name, string Title, string TemplateUrl, string Description)
            : this(Name, Title, TemplateUrl)
        {
            this.Description = Description;
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
        /// Gets or sets the page template URL.
        /// </summary>
        /// <value>
        /// The page template URL.
        /// </value>
        public string TemplateUrl
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

    }
}
