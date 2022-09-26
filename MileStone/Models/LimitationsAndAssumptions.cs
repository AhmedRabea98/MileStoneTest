using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MileStone.Models
{
    public class LimitationsAndAssumptions
    {
        [Key]
        public Guid LimitationsAndAssumptionsId { get; set; }
        public string Description { get; set; }
        public string Stage { get; set; }
        public string ImpactOnProjectOutputs { get; set; }
        public Guid? ProjectManagementPlanId { get; set; }

        [ForeignKey("ProjectManagementPlanId")]
        public virtual ProjectManagementPlan ProjectManagementPlan { get; set; }
    }
}
