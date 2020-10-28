using LanguageExt.Common;
using System;
using System.Collections.Generic;
using System.Text;
using static Question.Domain.CreateQuestionWorkflow.Question;

namespace Question.Domain.CreateQuestionWorkflow
{
    public class verifyQuestionService
    {
        public Result<ValidatedQuestion> VerifiedQuestion(InvalidatedQuestion question)
        {
            return new ValidatedQuestion(question.Question, question.Tags);
        }
    }
}
