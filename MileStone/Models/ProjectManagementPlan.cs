using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MileStone.Models
{
    public class ProjectManagementPlan
    {
        [Key]
        public Guid ProjectManagementPlanId { get; set; }
        public string ProjectManagementPlanName { get; set; }
        public int ProjectCode { get; set; }
        public string ProjectSponsor { get; set; }
        public string ProjectObjectives { get; set; }
        public string ProjectDescription { get; set; }
        public decimal ReturnOnInvestment { get; set; }
        public string ProjectDuration { get; set; }
        public DateTime PlannedStartDate { get; set; }
        public DateTime PlannedFinishDate { get; set; }
        public decimal ApprovedProjectBudget { get; set; }
        public string Deliverables { get; set; }
        public string Dependencies { get; set; }
        public string Procurement { get; set; }
        public string KeySuccessFactors { get; set; }
        public string ProjectLocation { get; set; }
        public string CompanyName { get; set; }
        public string KeyPerformanceIndicators { get; set; }
        public string KeyRisksIndicators { get; set; }
        public string KeyQualityIndicators { get; set; }
        public string BenefitsRealizationIndicators { get; set; }
        public string ROIIndicators { get; set; }
        public string NameOftheCriterion { get; set; }
        public string CheckTheQualityOfTheOutput { get; set; }
        public string ListOfFutilityOfCompletingTheProject { get; set; }
        public Guid? SectorID { get; set; }

        [ForeignKey("SectorID")]
        public virtual Sector Sector { get; set; }
        public ICollection<StrategicObjectives> StrategicObjectsives { get; set; }
        public ICollection<ProjectOutputsAndCost> ProjectOutputsAndCosts { get; set; }
        public ICollection<ImplementationTimeline> ImplementationTimelines { get; set; }
        public ICollection<LimitationsAndAssumptions> LimitationsAndAssumptions { get; set; }
        public ICollection<ResourceAndCadreManagement> ResourceAndCadreManagement { get; set; }
        public ICollection<Risk> Risks { get; set; }
        public ICollection<BeneficiariesandStakeholders> BeneficiariesandStakeholders { get; set; }
        public ICollection<ProjectRolesAndResources> ProjectRolesAndResources { get; set; }
        public ICollection<CommunicationPlan> CommunicationPlans { get; set; }
        public ICollection<BenefitRealizationPlan> BenefitRealizationPlans { get; set; }
        public ICollection<Comments> Comments { get; set; }
        public ICollection<Attachment> Attachments { get; set; }
    }
}
