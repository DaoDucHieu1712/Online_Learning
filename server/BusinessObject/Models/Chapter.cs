using System;
using System.Collections.Generic;

namespace BusinessObject.Models
{
    public partial class Chapter
    {
        public Chapter()
        {
            Lessons = new HashSet<Lesson>();
        }

        public int ChapterId { get; set; }
        public string? ChapterName { get; set; }
        public int? LessonId { get; set; }
        public int? CourseId { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public virtual Course? Course { get; set; }
        public virtual ICollection<Lesson> Lessons { get; set; }
    }
}
