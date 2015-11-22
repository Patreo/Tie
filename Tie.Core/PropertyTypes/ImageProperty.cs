using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Tie.PropertyTypes
{
    public class ImageProperty: IProperty
    {

        /// <summary>
        /// Gets or sets the width.
        /// </summary>
        /// <value>
        /// The width.
        /// </value>
        public Unit Width
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the height.
        /// </summary>
        /// <value>
        /// The height.
        /// </value>
        public Unit Height
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the image URL.
        /// </summary>
        /// <value>
        /// The image URL.
        /// </value>
        public string ImageUrl
        {
            get;
            set;
        }

        /// <summary>
        /// To the HTML.
        /// </summary>
        /// <returns></returns>
        public string ToHtml()
        {
            Page page = (Page)System.Web.HttpContext.Current.Handler;
            return String.Format("<img src=\"{0}\" style=\"width:{1};height:{2}\" />", page.ResolveUrl(this.ImageUrl), this.Width.ToString(), this.Height.ToString());
        }
    }
}
