using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MileStone.Context;
using MileStone.Models;
using MileStone.Services.BusinessCaseServices;

namespace MileStone.Controllers.BusinessCaseController
{ 
  /*  [Authorize]*/
    [Route("api/[controller]")]
    [ApiController]
    public class BusinessCasesController : ControllerBase
    {
        private readonly IBusinessCaseService businessCaseService;

        public BusinessCasesController(IBusinessCaseService businessCaseService)
        {
            this.businessCaseService = businessCaseService;
        }

        // GET: api/BusinessCases
        [HttpGet]
        public ActionResult<IEnumerable<BusinessCase>> GetBusinessCases()
        {
            return businessCaseService.GetBusinessCase();
        }

        // GET: api/BusinessCases/5
        [HttpGet("{id}")]
        public ActionResult<BusinessCase> GetBusinessCase(Guid id)
        {
            try
            {
                return businessCaseService.GetBusinessCase(id);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        // PUT: api/BusinessCases/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public BusinessCase PutBusinessCase(Guid id, BusinessCase businessCase)
        {
            try
            {
                return businessCaseService.UpdateBusinessCase(id , businessCase);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        // POST: api/BusinessCases
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [Route("AddBusinessCase")]
        [HttpPost]
        public ActionResult<BusinessCase> PostBusinessCase(BusinessCase businessCase)
        {
            try
            {
                return businessCaseService.AddBusinessCase(businessCase);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }

        // DELETE: api/BusinessCases/5
        [HttpDelete("{id}")]
        public void DeleteBusinessCase(Guid id)
        {
            try
            {
                 businessCaseService.DeleteBusinessCase(id);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        
    }
}
