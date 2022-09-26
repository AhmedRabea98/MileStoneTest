using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MileStone.Models
{

    public class StrategicObjectives
    {
        [Key]
        public Guid StrategicObjectivesId { get; set; }
        public string Goal { get; set; }
        public string LevelOfImpact { get; set; }
        public Guid? ProjectCharterId { get; set; }

        [ForeignKey("ProjectCharterId")]
        public virtual ProjectCharter ProjectCharter { get; set; }

        public Guid? ProjectManagementPlanId { get; set; }

        [ForeignKey("ProjectManagementPlanId")]
        public virtual ProjectManagementPlan ProjectManagementPlan { get; set; }    

    }
}
