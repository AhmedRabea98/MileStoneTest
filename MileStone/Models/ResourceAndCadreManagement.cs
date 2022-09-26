using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MileStone.Models
{
    public class ResourceAndCadreManagement
    {
        [Key]
        public Guid ResourceAndCadreManagementId { get; set; }
        public string Name { get; set; }
        public string Genre { get; set; }
        public string ExperienceLevel { get; set; }
        public string Management { get; set; }
        public int Number { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Activities { get; set; }
        public Guid? ProjectManagementPlanId { get; set; }

        [ForeignKey("ProjectManagementPlanId")]
        public virtual ProjectManagementPlan ProjectManagementPlan { get; set; }
    }
}
