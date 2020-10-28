using System;
using System.Collections.Generic;
using System.Text;

namespace Question.Domain.CreateQuestionWorkflow
{
    [Serializable]
    public class InvalidVotesException :Exception
    {
        public InvalidVotesException(int votes) : base($"Votes\"{votes}\"  is inccorect.")
        { 
        }
    }
}
