using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MileStone.Models
{
    public class BusinessCase
    {
        [Key]
        public Guid BusinessCaseID { get; set; }
        public string BusinessCaseName { get; set; }
        public string BusinessCaseDescription { get; set; }
        public string BusinessCaseIdea { get; set; }
        public string BusinessCaseJustification { get; set; }
        public string Importance { get; set; }
        public decimal EstimatedCost { get; set; }
        public DateTime ExpectedDuration { get; set; }
        public DateTime ExpectedStartDate { get; set; }
        public decimal EstimatedBudget { get; set; }
        public string CadresRequiredForTheProjectResources{get; set;}
        public string BusinessCaseImplementationMechanismProjectExecution { get; set; }
        public string TheExistenceOfTheRFPReadiness { get; set; }
        public string AssociatedStrategicObjectives { get; set; }
        public string AssociatedBudgetLineItem { get; set; }
        public int AssociatedBudgetLineItemNumber { get; set; }
        public string ImplementationObjectives { get; set; }
        public decimal ExpectedInvestmentValue { get; set; }
        public decimal PaybackPeriodInMonths { get; set; }
        public decimal FinalValueOfInvestmentInRiyals { get; set; }
        public decimal ReturnOnInvestmentROI { get; set; }
        public Guid? SectorID { get; set; }

        [ForeignKey("SectorID")]
        public virtual Sector Sector { get; set; }
        public Guid? DepartmentId { get; set; }

        [ForeignKey("DepartmentId")]
        public virtual Department Department { get; set; }

    
        public virtual ICollection<BusinessCaseWithProjects>  BusinessCasesWihtProjects { get; set; }
        public virtual ICollection<Risk> Risks { get; set; }
        public virtual ICollection<ProjectCashFlow> ProjectCashFlows { get; set; }
        public virtual ICollection<Comments>  Comments { get; set; }
        public virtual ICollection<Attachment> Attachments { get; set; }
        public virtual ICollection<BeneficiariesandStakeholders> BeneficiariesandStakeholders { get; set; }


    }
}

