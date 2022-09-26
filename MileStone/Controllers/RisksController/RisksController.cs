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
using MileStone.Services.RisksServices;

namespace MileStone.Controllers.RisksController
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class RisksController : ControllerBase
    {
        private readonly IRisksService risksService;

        public RisksController(IRisksService risksService)
        {
            this.risksService = risksService;
        }

        // GET: api/Risks
        [HttpGet]
        public ActionResult<IEnumerable<Risk>> GetRisks()
        {
            return risksService.GetRisks();
        }

        // GET: api/Risks/5
        [HttpGet("{id}")]
        public ActionResult<Risk> GetRisk(Guid id)
        {
            try
            {
                return risksService.GetRisk(id);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        // PUT: api/Risks/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public Risk PutRisks(Guid id, Risk risks)
        {
            try
            {
                return risksService.UpdateRisk(id , risks);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        // POST: api/Risks
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public ActionResult<Risk> PostRisks(Risk risks)
        {
            try
            {
                return risksService.AddRisk(risks);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        // DELETE: api/Risks/5
        [HttpDelete("{id}")]
        public void DeleteRisks(Guid id)
        {
            try
            {
                 risksService.DeleteRisk(id);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        
    }
}
