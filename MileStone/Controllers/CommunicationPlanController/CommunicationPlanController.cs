using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MileStone.Models;
using MileStone.Services.CommunicationPlanServices;
using System;
using System.Collections.Generic;

namespace MileStone.Controllers.CommunicationPlanController
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommunicationPlanController : ControllerBase
    {
        private readonly ICommunicationPlanService communicationPlanService;
        public CommunicationPlanController(ICommunicationPlanService communicationPlanService)
        {
            this.communicationPlanService= communicationPlanService;
        }
        [HttpGet]
        public ActionResult<IEnumerable<CommunicationPlan>> GetCommunicationPlans()
        {
            return communicationPlanService.GetCommunicationPlans();
        }

        // GET: api/BusinessCases/5
        [HttpGet("{id}")]
        public ActionResult<CommunicationPlan> GetCommunicationPlan(Guid id)
        {
            try
            {
                return communicationPlanService.GetCommunicationPlan(id);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        // PUT: api/BusinessCases/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public CommunicationPlan PutCommunicationPlan(Guid id, CommunicationPlan communicationPlan)
        {
            try
            {
                return communicationPlanService.UpdateCommunicationPlan(id, communicationPlan);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        // POST: api/BusinessCases
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public ActionResult<CommunicationPlan> PostCommunicationPlan(CommunicationPlan communicationPlan)
        {
            try
            {
                return communicationPlanService.AddCommunicationPlan(communicationPlan);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }

        // DELETE: api/BusinessCases/5
        [HttpDelete("{id}")]
        public void DeleteCommunicationPlan(Guid id)
        {
            try
            {
                communicationPlanService.DeleteCommunicationPlan(id);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
