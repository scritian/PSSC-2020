﻿using System.ComponentModel.DataAnnotations;

namespace StackUnderflow.Domain.Core.Contexts.Questions.CreateQuestionsOp
{
    public class CreateQuestionsCmd
    {
        [Required]
        public int QuestionId { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string Tags { get; set; }

        public CreateQuestionsCmd() { }
        public CreateQuestionsCmd(int QuestionId, string Title, string Description, string Tags)
        {
            this.QuestionId = QuestionId;
            this.Title = Title;
            this.Description = Description;
            this.Tags = Tags;
        }
    }
}