using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MileStone.Models;
using MileStone.Services.BenefitRealizationPlanServices;
using System;
using System.Collections.Generic;

namespace MileStone.Controllers.BenefitRealizationPlanController
{
    [Route("api/[controller]")]
    [ApiController]
    public class BenefitRealizationPlanController : ControllerBase
    {
        private readonly IBenefitRealizationPlanService benefitRealizationPlanService;
        public BenefitRealizationPlanController(IBenefitRealizationPlanService benefitRealizationPlanService)
        {
            this.benefitRealizationPlanService = benefitRealizationPlanService; 
        }
        [HttpGet]
        public ActionResult<IEnumerable<BenefitRealizationPlan>> GetBenefitRealizationPlans()
        {
            return benefitRealizationPlanService.GetBenefitRealizationPlans();
        }

        // GET: api/BusinessCases/5
        [HttpGet("{id}")]
        public ActionResult<BenefitRealizationPlan> GetBenefitRealizationPlan(Guid id)
        {
            try
            {
                return benefitRealizationPlanService.GetBenefitRealizationPlan(id);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        // PUT: api/BusinessCases/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public BenefitRealizationPlan PutBenefitRealizationPlan(Guid id, BenefitRealizationPlan benefitRealizationPlan)
        {
            try
            {
                return benefitRealizationPlanService.UpdateBenefitRealizationPlan(id, benefitRealizationPlan);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        // POST: api/BusinessCases
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public ActionResult<BenefitRealizationPlan> PostBenefitRealizationPlan(BenefitRealizationPlan benefitRealizationPlan)
        {
            try
            {
                return benefitRealizationPlanService.AddBenefitRealizationPlan(benefitRealizationPlan);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }

        // DELETE: api/BusinessCases/5
        [HttpDelete("{id}")]
        public void DeleteBenefitRealizationPlan(Guid id)
        {
            try
            {
                benefitRealizationPlanService.DeleteBenefitRealizationPlan(id);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
