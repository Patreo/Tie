﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tie.PropertyTypes
{
    public class TextProperty : IProperty
    {
        public string Value
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