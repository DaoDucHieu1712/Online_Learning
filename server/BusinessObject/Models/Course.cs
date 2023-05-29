using System;
using System.Collections.Generic;

namespace BusinessObject.Models
{
    public partial class Course
    {
        public Course()
        {
            Certificates = new HashSet<Certificate>();
            Chapters = new HashSet<Chapter>();
            Comments = new HashSet<Comment>();
            OrderDetails = new HashSet<OrderDetail>();
            Accounts = new HashSet<Account>();
            Categories = new HashSet<Category>();
        }

        public int CourseId { get; set; }
        public string? CourseName { get; set; }
        public string? Image { get; set; }
        public string? Description { get; set; }
        public decimal? Price { get; set; }
        public int? IsActive { get; set; }
        public int? AuthorId { get; set; }
        public bool? IsDelete { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public virtual ICollection<Certificate> Certificates { get; set; }
        public virtual ICollection<Chapter> Chapters { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }

        public virtual ICollection<Account> Accounts { get; set; }
        public virtual ICollection<Category> Categories { get; set; }
    }
}
