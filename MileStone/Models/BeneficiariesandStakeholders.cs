using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MileStone.Models
{
    public class BeneficiariesandStakeholders
    {
        [Key]
        public Guid BeneficiariesandStakeholdersId { get; set; }
        public string Name { get; set; }
        public string Role { get; set; }
        public string LevelOfImpact { get; set; }
        public string Entity { get; set; }
        public string CommunicationTools { get; set; }
        public string Requirements { get; set; }
        public string Expectations { get; set; }
        public Guid? BusinessCaseId { get; set; }

        [ForeignKey("BusinessCaseId")]
        public virtual BusinessCase BusinessCase { get; set; }
        public Guid? ProjectCharterId { get; set; }

        [ForeignKey("ProjectCharterId")]
        public virtual ProjectCharter ProjectCharter { get; set; }
        public Guid? ProjectManagementPlanId { get; set; }

        [ForeignKey("ProjectManagementPlanId")]
        public virtual ProjectManagementPlan ProjectManagementPlan { get; set; }
    }
}
