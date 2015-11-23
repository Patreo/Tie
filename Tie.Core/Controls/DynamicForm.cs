using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Tie.Data;
using Tie.Web;

namespace Tie.Controls
{

    [ToolboxData("<{0}:DynamicForm runat=server />")]
    [ToolboxItem(true)]
    public class DynamicForm : WebControl, INamingContainer
    {
        private Tie.Data.Store.PageType pageType;
        private IEnumerable<Tie.Data.Store.PropertyType> propertyTypes;

        /// <summary>
        /// Gets or sets the database.
        /// </summary>
        /// <value>
        /// The database.
        /// </value>
        [Browsable(true)]
        public Database Database
        {
            get;
            set;
        }        

        /// <summary>
        /// Binds a data source to the invoked server control and all its child controls.
        /// </summary>
        public override void DataBind()
        {
            string strQualifiedName = this.Page.GetType().BaseType.BaseType.GetGenericArguments()[0].FullName;
            this.pageType = this.Database.Store.PageTypes.All().Where((item) => item.QualifiedName == strQualifiedName).FirstOrDefault();

            if (this.pageType == null)
            {
                throw new Exception(strQualifiedName + " not founded, this page not exists any more.");
            }

            this.propertyTypes = this.Database.Store.PropertyTypes.All().Where((item) => item.PageTypeID == this.pageType.ID);            
            base.DataBind();
        }

        /// <summary>
        /// Renders the HTML opening tag of the control to the specified writer. This method is used primarily by control developers.
        /// </summary>
        /// <param name="writer">A <see cref="T:System.Web.UI.HtmlTextWriter" /> that represents the output stream to render HTML content on the client.</param>
        public override void RenderBeginTag(HtmlTextWriter writer)
        {
            writer.RenderBeginTag(HtmlTextWriterTag.Div);
        }

        /// <summary>
        /// Renders the HTML closing tag of the control into the specified writer. This method is used primarily by control developers.
        /// </summary>
        /// <param name="writer">A <see cref="T:System.Web.UI.HtmlTextWriter" /> that represents the output stream to render HTML content on the client.</param>
        public override void RenderEndTag(HtmlTextWriter writer)
        {
            writer.RenderEndTag();
        }

        /// <summary>
        /// Sends server control content to a provided <see cref="T:System.Web.UI.HtmlTextWriter" /> object, which writes the content to be rendered on the client.
        /// </summary>
        /// <param name="writer">The <see cref="T:System.Web.UI.HtmlTextWriter" /> object that receives the server control content.</param>
        protected override void Render(HtmlTextWriter writer)
        {
            base.Render(writer);
        }

        /// <summary>
        /// Raises the <see cref="E:System.Web.UI.Control.Init" /> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs" /> object that contains the event data.</param>
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            this.ChildControlsCreated = true;
            this.Page.RegisterRequiresControlState(this);
        }      

        /// <summary>
        /// Raises the <see cref="E:System.Web.UI.Control.PreRender" /> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs" /> object that contains the event data.</param>
        protected override void OnPreRender(EventArgs e)
        {
            this.CreateChildControls();
            base.OnPreRender(e);            
        }

        /// <summary>
        /// Called by the ASP.NET page framework to notify server controls that use composition-based implementation to create any child controls they contain in preparation for posting back or rendering.
        /// </summary>
        protected override void CreateChildControls()
        {
            foreach (Tie.Data.Store.PropertyType propertyType in this.propertyTypes)
            {
                UserProperty control = (UserProperty)Page.LoadControl(propertyType.Editor);

                if (control == null)
                {
                    throw new Exception(propertyType.Editor + " not founded.");
                }

                string strPath = HttpContext.Current.Request.Path;
                if (strPath.StartsWith("/"))
                {
                    strPath = strPath.Substring(1, strPath.Length - 1);
                }

                Tie.Data.Store.Page page = this.Database.Store.Pages.All()
                    .Where((item) => item.PageTypeID == this.pageType.ID && item.Slug.ToLower() == strPath.ToLower())
                    .FirstOrDefault();

                Tie.Data.Store.PageProperty pageProperty = this.Database.Store.PageProperties.All()
                    .Where((item) => item.PageID == page.ID && item.PropertyTypeID == propertyType.ID)
                    .FirstOrDefault();

                control.Name = propertyType.Name;
                control.Label = propertyType.Title;

                if (pageProperty != null)
                {
                    control.Value = pageProperty.Content ?? "";
                }

                PlaceHolder placeHolder = new PlaceHolder();
                placeHolder.Controls.Add(control);
                this.Controls.Add(placeHolder);
            }
        }

    
    }
}
