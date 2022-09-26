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
using MileStone.Services.SectorsServices;

namespace MileStone.Controllers.SelectorController
{
   // [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class SectorsController : ControllerBase
    {

        private readonly ISectorsService sectorsService;
        public SectorsController(ISectorsService sectorsService)
        {
            this.sectorsService = sectorsService;
        }

        // GET: api/Selectors
        [HttpGet]
        public ActionResult<IEnumerable<Sector>> GetSelector()
        {
            return sectorsService.GetSectors();
        }

        // GET: api/Selectors/5
        [HttpGet("{id}")]
        public ActionResult<Sector> GetSelector(Guid id)
        {
            try
            {
                return sectorsService.GetSector(id);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        // PUT: api/Selectors/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public Sector PutSelector(Guid id, Sector sector)
        {
            try
            {
                return sectorsService.UpdateSector(id,sector);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        // POST: api/Selectors
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Sector>> PostSelector(Sector sector)
        {
            try
            {
                return sectorsService.AddSector(sector);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        // DELETE: api/Selectors/5
        [HttpDelete("{id}")]
        public void DeleteSelector(Guid id)
        {
            try
            {
                 sectorsService.DeleteSector(id);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

       
    }
}
