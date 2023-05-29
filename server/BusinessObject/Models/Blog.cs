using System;
using System.Collections.Generic;

namespace BusinessObject.Models
{
    public partial class Blog
    {
        public Blog()
        {
            Comments = new HashSet<Comment>();
        }

        public int BlogId { get; set; }
        public string? Title { get; set; }
        public string? Image { get; set; }
        public string? Content { get; set; }
        public int? AuthorId { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public virtual Account? Author { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
    }
}
