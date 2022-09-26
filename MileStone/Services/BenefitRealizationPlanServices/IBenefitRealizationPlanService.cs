using MileStone.Models;
using System;
using System.Collections.Generic;

namespace MileStone.Services.BenefitRealizationPlanServices
{
    public interface IBenefitRealizationPlanService
    {
        public List<BenefitRealizationPlan> GetBenefitRealizationPlans();
        public BenefitRealizationPlan GetBenefitRealizationPlan(Guid Id);
        public BenefitRealizationPlan AddBenefitRealizationPlan(BenefitRealizationPlan benefitRealizationPlan);
        public BenefitRealizationPlan UpdateBenefitRealizationPlan(Guid Id, BenefitRealizationPlan benefitRealizationPlan);
        public void DeleteBenefitRealizationPlan(Guid Id);
    }
}
