using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MileStone.Models
{
    public class ProjectCharter
    {
        [Key]
        public Guid ProjectCharterId { get; set; }
        public string ProjectName { get; set; }
        public int ProjectCode { get; set; }
        public string ProjectSponsor { get; set; }
        public string ProjectObjectives { get; set; }
        public string ProjectDescription { get; set; }
        public string ProjectBenefits { get; set; }
        public decimal ReturnOnInvestment { get; set; }
        public string ProjectDuration { get; set; }
        public decimal ApprovedBudget { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime FinishDate { get; set; }
        public string ProjectDeliverables { get; set; }
        public string Assumptions { get; set; }
        public string ProjectLimitations { get; set; }
        public string Dependencies { get; set; }
        public string ProjectPurchasesProcurement { get; set; }
        public string KeySuccessFactors { get; set; }
        public string ProjectLocation { get; set; }
        public string ImplementingEntityCompanyName { get; set; }
        public string PerformanceMeasurementStandard_CriteriaKeyPerformanceIndicators { get; set; }
        public string RiskMeasurementCriteriaKeyRisksIndicators { get; set; }
        public string QualityMeasurementStandardsKeyQualityIndicators { get; set; }
        public string CriteriaForMeasuringTheAchievementOfBenefitsRealizationIndicators { get; set; }
        public string CriteriaForMeasuringreturnOnInvestmentROIIndicators { get; set; }
        public string InScope { get; set; }
        public string OutOfWork { get; set; }
        public string ProjectManagerName { get; set; }
        public string ValidityName { get; set; }
        public string RecruitmentOfCadres { get; set; }
        public string ApprovalOfContracts { get; set; }
        public string ApproveChangeOrders { get; set; }
        public string OutputAccreditation { get; set; }
        public string NameOftheCriterion { get; set; }
        public string CheckTheQualityOfTheOutput { get; set; }
        public string ListOfFutilityOfCompletingTheProject { get; set; }
        public Guid? SectorID { get; set; }

        [ForeignKey("SectorID")]
        public virtual Sector Sector { get; set; }

        public virtual ICollection<StrategicObjectives> StrategicObjectives { get; set; }
        public virtual ICollection<Comments> Comments { get; set; }
        public virtual ICollection<Attachment> Attachments { get; set; }
        public virtual ICollection<Risk> Risks { get; set; }
        public virtual ICollection<BeneficiariesandStakeholders> BeneficiariesandStakeholders { get; set; }
        public virtual ICollection<ProjectRolesAndResources> ProjectRolesAndResources { get; set; }
    }
}
