﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tie.PropertyTypes
{
    public class NumericProperty : IProperty
    {
        public int Value
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
