using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MileStone.Models
{
    public class Project
    {
        [Key]
        public Guid ProjectId { get; set; }
        public string ProjectName { get; set; }
        public virtual ICollection<BusinessCaseWithProjects> BusinessCasesWihtProjects { get; set; }

    }
}
