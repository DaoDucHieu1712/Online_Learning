using System;
using System.Collections.Generic;

namespace BusinessObject.Models
{
    public partial class Account
    {
        public Account()
        {
            Blogs = new HashSet<Blog>();
            Certificates = new HashSet<Certificate>();
            Comments = new HashSet<Comment>();
            Courses = new HashSet<Course>();
            Lessons = new HashSet<Lesson>();
            Permissions = new HashSet<Permission>();
        }

        public int AccountId { get; set; }
        public string? FullName { get; set; }
        public string? Image { get; set; }
        public bool? Gender { get; set; }
        public DateTime? Dob { get; set; }
        public string? Address { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public int? Role { get; set; }

        public virtual ICollection<Blog> Blogs { get; set; }
        public virtual ICollection<Certificate> Certificates { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }

        public virtual ICollection<Course> Courses { get; set; }
        public virtual ICollection<Lesson> Lessons { get; set; }
        public virtual ICollection<Permission> Permissions { get; set; }
    }
}
