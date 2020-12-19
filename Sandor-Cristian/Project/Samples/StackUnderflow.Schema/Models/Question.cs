using System.ComponentModel.DataAnnotations.Schema;

namespace StackUnderflow.DatabaseModel.Models
{
    [Table("Question")]
    public class Question
    {
        public int QuestionId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Tags { get; set; }
    }
}