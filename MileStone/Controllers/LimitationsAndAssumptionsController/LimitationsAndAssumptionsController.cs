using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MileStone.Models;
using MileStone.Services.LimitationsAndAssumptionsServices;
using System;
using System.Collections.Generic;

namespace MileStone.Controllers.LimitationsAndAssumptionsController
{
    [Route("api/[controller]")]
    [ApiController]
    public class LimitationsAndAssumptionsController : ControllerBase
    {
        private readonly ILimitationsAndAssumptionsService limitationsAndAssumptionsService;
        public LimitationsAndAssumptionsController(ILimitationsAndAssumptionsService limitationsAndAssumptionsService)
        {
            this.limitationsAndAssumptionsService = limitationsAndAssumptionsService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<LimitationsAndAssumptions>> GetLimitationsAndAssumptions()
        {
            return limitationsAndAssumptionsService.GetLimitationsAndAssumptions();
        }

        // GET: api/BusinessCases/5
        [HttpGet("{id}")]
        public ActionResult<LimitationsAndAssumptions> GetLimitationsAndAssumptions(Guid id)
        {
            try
            {
                return limitationsAndAssumptionsService.GetLimitationsAndAssumptions(id);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        // PUT: api/BusinessCases/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public LimitationsAndAssumptions PutLimitationsAndAssumptions(Guid id, LimitationsAndAssumptions limitationsAndAssumptions)
        {
            try
            {
                return limitationsAndAssumptionsService.UpdateLimitationsAndAssumptions(id, limitationsAndAssumptions);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        // POST: api/BusinessCases
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public ActionResult<LimitationsAndAssumptions> PostLimitationsAndAssumptions(LimitationsAndAssumptions limitationsAndAssumptions)
        {
            try
            {
                return limitationsAndAssumptionsService.AddLimitationsAndAssumptions(limitationsAndAssumptions);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }

        // DELETE: api/BusinessCases/5
        [HttpDelete("{id}")]
        public void DeleteLimitationsAndAssumptions(Guid id)
        {
            try
            {
                limitationsAndAssumptionsService.DeleteLimitationsAndAssumptions(id);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
