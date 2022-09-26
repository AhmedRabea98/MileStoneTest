using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MileStone.Models
{
    public class CommunicationPlan
    {
        [Key]
        public Guid CommunicationPlanId { get; set; }
        public string ConcernedParty { get; set; }
        public string Entity { get; set; }
        public string Role { get; set; }
        public string Message { get; set; }
        public string Contact { get; set; }
        public string CommunicationTiming { get; set; }
        public string Observations { get; set; }
        public Guid? ProjectManagementPlanId { get; set; }

        [ForeignKey("ProjectManagementPlanId")]
        public virtual ProjectManagementPlan ProjectManagementPlan { get; set; }
    }
}
