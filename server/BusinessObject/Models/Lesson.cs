using System;
using System.Collections.Generic;

namespace BusinessObject.Models
{
    public partial class Lesson
    {
        public Lesson()
        {
            Accounts = new HashSet<Account>();
        }

        public int LessonId { get; set; }
        public string? LessonName { get; set; }
        public int? ChapterId { get; set; }
        public string? Content { get; set; }
        public string? Video { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public virtual Chapter? Chapter { get; set; }

        public virtual ICollection<Account> Accounts { get; set; }
    }
}
