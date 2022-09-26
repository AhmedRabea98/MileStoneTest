using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MileStone.Models
{
    public class Risk
    {
        [Key]
        public Guid RiskId { get; set; }
        public string RiskTitle { get; set; }
        public string RiskStatus { get; set; }
        public DateTime DateOccurred { get; set; }
        public DateTime DateClose { get; set; }
        public String Severity { get; set; }
        public string Description { get; set; }
        public string Impact { get; set; }
        public string IntialDispostion { get; set; }
        public string Owner { get; set; }
        public string Stage { get; set; }
        public string Administrator { get; set; }
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
