using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tie.Web
{
    public class PageTemplate<T>
    {
        public PageTemplate()
        {

        }

        public T ThisPage 
        { 
            get; 
            set; 
        }
    }
}
