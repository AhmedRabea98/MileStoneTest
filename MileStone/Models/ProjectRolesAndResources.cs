using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MileStone.Models
{
    public class ProjectRolesAndResources
    {
        [Key]
        public Guid ProjectRolesandResourcesId { get; set; }
        public string NameOfThePerson { get; set; } 
        public string Role { get; set; }
        public string Impact { get; set; }
        public string CommunicationTools { get; set; }

        public Guid? ProjectCharterId { get; set; }

        [ForeignKey("ProjectCharterId")]
        public ProjectCharter ProjectCharter { get; set; }
        public Guid? ProjectManagementPlanId { get; set; }

        [ForeignKey("ProjectManagementPlanId")]
        public virtual ProjectManagementPlan ProjectManagementPlan { get; set; }

    }
}
