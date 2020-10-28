﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace Question.Domain.CreateQuestionWorkflow
{
    public struct CreateQuestionCmd
    {
        [Required]
        [MaxLength(1000)]
        public string Title { get; private set; }
        [Required]
        public string Body { get; private set; }
        [Required]
        public string Tag { get; private set; }

        public CreateQuestionCmd(string title, string body, string tag)
        {
            Title = title;
            Body = body;
            Tag = tag;
        }
    }
}
