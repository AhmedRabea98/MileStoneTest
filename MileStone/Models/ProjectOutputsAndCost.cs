using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MileStone.Models
{
    public class ProjectOutputsAndCost
    {
        [Key]
        public Guid? ProjectOutputsAndCostId { get; set; }
        public string DescriptionOfTheScopeOfWork { get; set; }
        public string Stage { get; set; }
        public string MainMileStone { get; set; }
        public decimal Cost { get; set; }
        public Guid? ProjectManagementPlanId { get; set; }

        [ForeignKey("ProjectManagementPlanId")]
        public virtual ProjectManagementPlan ProjectManagementPlan { get; set; }
    }
}
