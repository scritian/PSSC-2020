using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using static Question.Domain.CreateQuestionWorkflow.Question;

namespace Question.Domain.CreateQuestionWorkflow
{
    public class verifyVoteService
    {
        public Task Vote(ValidatedQuestion question)
        {
            return Task.CompletedTask;
        }
    }
}
