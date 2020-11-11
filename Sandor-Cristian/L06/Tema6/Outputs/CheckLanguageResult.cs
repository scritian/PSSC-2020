using System;
using System.Collections.Generic;
using System.Text;
using CSharp.Choices;

namespace Tema6.Outputs
{
    [AsChoice]
    public static partial class CheckLanguageResult 
    {
        public interface ICheckLanguageResult {}

        public class SafeText : ICheckLanguageResult
        {
        }
    }
}
