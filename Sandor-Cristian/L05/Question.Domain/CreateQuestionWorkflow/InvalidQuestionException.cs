using System;
using System.Collections.Generic;
using System.Text;

namespace Question.Domain.CreateQuestionWorkflow
{
    [Serializable]
    public class InvalidQuestionException : Exception
    {
        public InvalidQuestionException()
        {
        }

        public InvalidQuestionException(string error) : base($"Error: \"{error}\"")
        {
        }

    }
}
