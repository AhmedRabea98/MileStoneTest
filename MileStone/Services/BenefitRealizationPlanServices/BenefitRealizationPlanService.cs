using Microsoft.EntityFrameworkCore;
using MileStone.Context;
using MileStone.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MileStone.Services.BenefitRealizationPlanServices
{
    public class BenefitRealizationPlanService : IBenefitRealizationPlanService
    {
        private readonly DBContext context;
        public BenefitRealizationPlanService(DBContext context)
        {
                this.context = context; 
        }
        public BenefitRealizationPlan AddBenefitRealizationPlan(BenefitRealizationPlan benefitRealizationPlan)
        {
            if (benefitRealizationPlan == null)
            {
                throw new NotImplementedException();


            }
            else
            {
                context.BenefitRealizationPlans.Add(benefitRealizationPlan);
                context.SaveChanges();
                return benefitRealizationPlan;
            }
        }

        public void DeleteBenefitRealizationPlan(Guid Id)
        {
            var benefitRealizationPlans = context.BenefitRealizationPlans.FirstOrDefault(e => e.BenefitRealizationPlanId == Id);
            if (benefitRealizationPlans == null)
            {
                throw new NotImplementedException();

            }
            context.BenefitRealizationPlans.Remove(benefitRealizationPlans);
            context.SaveChanges();
        }

        public BenefitRealizationPlan GetBenefitRealizationPlan(Guid Id)
        {
            var benefitRealizationPlans = context.BenefitRealizationPlans.FirstOrDefault(e => e.BenefitRealizationPlanId == Id);
            if(benefitRealizationPlans == null)
            {
                throw new NotImplementedException();

            }
            else
            {
                return benefitRealizationPlans;
            }
        }

        public List<BenefitRealizationPlan> GetBenefitRealizationPlans()
        {
            return context.BenefitRealizationPlans.ToList();
        }

        public BenefitRealizationPlan UpdateBenefitRealizationPlan(Guid Id, BenefitRealizationPlan benefitRealizationPlan)
        {
            if (Id != benefitRealizationPlan.BenefitRealizationPlanId)
            {
                throw new NotImplementedException();

            }
            else
            {
                context.Entry(benefitRealizationPlan).State = EntityState.Modified;
                context.SaveChanges();
                return benefitRealizationPlan;
            }
        }
    }
}
