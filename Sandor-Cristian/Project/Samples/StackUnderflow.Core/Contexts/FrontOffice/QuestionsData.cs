using StackUnderflow.EF.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Access.Primitives.IO;

namespace StackUnderflow.Domain.Core.Contexts.FrontOffice
{

    public enum QuestionsDataInput
    {
        Empty,
        Nulls
    }

    public class QuestionsDataGen : InputGenerator<QuestionsData, QuestionsDataInput>
    {
        public QuestionsDataGen()
        {
            mappings.Add(QuestionsDataInput.Empty, () => new QuestionsData(new List<Post>()));
            mappings.Add(QuestionsDataInput.Nulls, () => new QuestionsData(null));
        }
    }


    public class QuestionsData
    {
        public QuestionsData(ICollection<Post> questions)
        {
            Questions = questions;
        }

        public ICollection<Post> Questions { get; }
    }
}
