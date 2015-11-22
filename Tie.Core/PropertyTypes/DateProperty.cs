using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tie.PropertyTypes
{
    public class DateProperty : IProperty
    {

        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        /// <value>
        /// The value.
        /// </value>
        public DateTime Value 
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
            return this.Value.ToString("{0:dd-MM-yyyy}");
        }     
    }
}
