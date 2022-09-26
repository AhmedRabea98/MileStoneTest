using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MileStone.Models
{
    public class BenefitRealizationPlan
    {
        [Key]
        public Guid BenefitRealizationPlanId { get; set; }
        public string DescriptionOfBenefits { get; set; }
        public string Type { get; set; }
        public string Target { get; set; }
        public string InvestigatorRatio { get; set; }
        public string Responsible { get; set; }
        public string RelatedOutputs { get; set; }
        public string Observations { get; set; }
        public Guid? ProjectManagementPlanId { get; set; }

        [ForeignKey("ProjectManagementPlanId")]
        public virtual ProjectManagementPlan ProjectManagementPlan { get; set; }
    }
}
