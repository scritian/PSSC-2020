using CSharp.Choices;
using LanguageExt.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Question.Domain.CreateQuestionWorkflow
{
    [AsChoice]
    public static partial class Question
    {
        public interface IQuestion { };
        public class InvalidatedQuestion : IQuestion
        {
            public string Question { get; private set; }
            public string Tags { get; private set; }

            public InvalidatedQuestion(string question, string tags)
            {
                Question = question;
                Tags = tags;
            }
            public static Result<InvalidatedQuestion> Create(string question, string tags)
            {
                if (IsQuestionTitleValid(question))
                {
                    if (IsQuestionTagsValid(tags))
                    {
                        return new InvalidatedQuestion(question, tags);
                    }
                    else
                    {
                        return new Result<InvalidatedQuestion>(new InvalidQuestionException("The number of tags must be between 1 and 3."));
                    }
                }
                else
                {
                    return new Result<InvalidatedQuestion>(new InvalidQuestionException("The question exeeds 1000 characters."));
                }

            }

            private static bool IsQuestionTitleValid(string question)
            {
                if (question.Length <= 1000)
                {
                    return true;
                }
                return false;
            }

            private static bool IsQuestionTagsValid(string tags)
            {
                if (tags.Split(' ').Length < 4 && tags.Split(' ').Length > 0)
                {
                    return true;
                }
                return false;
            }

        }
        public class ValidatedQuestion : IQuestion
        {
            public string Question { get; private set; }
            public string Tags { get; private set; }

            internal ValidatedQuestion(string question, string tags)
            {
                Question = question;
                Tags = tags;
            }
        }

    }
}
