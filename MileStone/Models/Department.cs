using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MileStone.Models
{
    public class Department
    {
        [Key]
        public Guid DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        public virtual ICollection<BusinessCase> BusinessCases { get; set; }
    }
}
