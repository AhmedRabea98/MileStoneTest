using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MileStone.Models
{
    public class Comments
    {
        [Key]
        public Guid CommentsId { get; set; }
        public string Description { get; set; }

        public Guid? BusinessCaseID { get; set; }

        [ForeignKey("BusinessCaseID")]
        public virtual BusinessCase BusinessCase { get; set; }

        public Guid? ProjectCharterId { get; set; }

        [ForeignKey("ProjectCharterId")]
        public virtual ProjectCharter ProjectCharter { get; set; }
        public Guid? ProjectManagementPlanId { get; set; }

        [ForeignKey("ProjectManagementPlanId")]
        public virtual ProjectManagementPlan ProjectManagementPlan { get; set; }
    }
}
