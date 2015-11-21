using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tie.PropertyTypes
{
    public class DateProperty : IProperty
    {
        public DateTime Value 
        { 
            get; 
            set;
        }

        public string ToHtml()
        {
            throw new NotImplementedException();
        }
    }
}
