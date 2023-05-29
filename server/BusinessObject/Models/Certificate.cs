using System;
using System.Collections.Generic;

namespace BusinessObject.Models
{
    public partial class Certificate
    {
        public int CertificateId { get; set; }
        public int? CourseId { get; set; }
        public int? AccountId { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public virtual Account? Account { get; set; }
        public virtual Course? Course { get; set; }
    }
}
