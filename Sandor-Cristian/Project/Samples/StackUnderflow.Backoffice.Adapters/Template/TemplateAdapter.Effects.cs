using System;
using System.Collections.Generic;
using System.Text;
using Access.Primitives.IO.Mocking;

namespace StackUnderflow.Backoffice.Adapters.Template
{
    public partial class TemplateAdapter
    {
        public enum Case1
        {
            ValidCase,
            InvalidCase
        }

        public enum Effect1
        {
            OK, 
            ThrowsException
        }
    }
}
