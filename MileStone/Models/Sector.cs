using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MileStone.Models
{
    public class Sector
    { 
        [Key]
        public Guid SectorId { get; set; }
        public string SectorName { get; set; }   
        public virtual ICollection<BusinessCase> BusinessCases { get; set; }
        public virtual ICollection<ProjectCharter> ProjectCharter { get; set; }
        public virtual ICollection<ProjectManagementPlan> ProjectManagementPlan { get; set; }
    }
}
