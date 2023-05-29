using System;
using System.Collections.Generic;

namespace BusinessObject.Models
{
    public partial class Category
    {
        public Category()
        {
            InverseParentCategory = new HashSet<Category>();
            Courses = new HashSet<Course>();
        }

        public int CategoryId { get; set; }
        public string? CategoryName { get; set; }
        public string? Description { get; set; }
        public int? IsActive { get; set; }
        public bool? IsDelete { get; set; }
        public int? ParentCategoryId { get; set; }

        public virtual Category? ParentCategory { get; set; }
        public virtual ICollection<Category> InverseParentCategory { get; set; }

        public virtual ICollection<Course> Courses { get; set; }
    }
}
