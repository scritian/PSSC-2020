using System;
using System.Collections.Generic;
using System.Text;
using CSharp.Choices;

namespace L06.Outputs
{
    [AsChoice]
    public static partial class CheckLanguageResult
    {
        public interface ICheckLanguageResult { }

        public class TextChecked : ICheckLanguageResult
        {
            public int Certainty { get; private set; }

            public TextChecked(int certainty)
            {
                Certainty = certainty;
            }
        }

        public class CheckFailed : ICheckLanguageResult
        {
            public string ErrorMessage { get; private set; }

            public CheckFailed(string errorMessage)
            {
                ErrorMessage = errorMessage;
            }
        }
    }
}
