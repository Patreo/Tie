using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tie.Web
{
    public class UserProperty : System.Web.UI.UserControl
    {
        /// <summary>
        /// Gets or sets the label.
        /// </summary>
        /// <value>
        /// The label.
        /// </value>
        public virtual string Label
        {
            get { return ViewState["Value"] as String; }
            set { ViewState["Value"] = value; }
        }

        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        /// <value>
        /// The value.
        /// </value>
        public virtual string Value
        {
            get { return ViewState["Value"] as String; }
            set { ViewState["Value"] = value; }
        }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public virtual string Name
        {
            get { return ViewState["Value"] as String; }
            set { ViewState["Value"] = value; }
        }
    }
}
