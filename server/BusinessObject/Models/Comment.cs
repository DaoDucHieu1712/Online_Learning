using System;
using System.Collections.Generic;

namespace BusinessObject.Models
{
    public partial class Comment
    {
        public Comment()
        {
            InverseRely = new HashSet<Comment>();
        }

        public int CommentId { get; set; }
        public string? Message { get; set; }
        public int? BlogId { get; set; }
        public int? CourseId { get; set; }
        public int? RelyId { get; set; }
        public int? AccountId { get; set; }

        public virtual Account? Account { get; set; }
        public virtual Blog? Blog { get; set; }
        public virtual Course? Course { get; set; }
        public virtual Comment? Rely { get; set; }
        public virtual ICollection<Comment> InverseRely { get; set; }
    }
}
