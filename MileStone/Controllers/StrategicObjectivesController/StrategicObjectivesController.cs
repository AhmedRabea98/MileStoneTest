using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MileStone.Models;
using MileStone.Services.StrategicObjectivesServices;
using System;
using System.Collections.Generic;

namespace MileStone.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StrategicObjectivesController : ControllerBase
    {
        private readonly IStrategicObjectivesService strategicObjectivesService;
        public StrategicObjectivesController(IStrategicObjectivesService strategicObjectivesService)
        {
            this.strategicObjectivesService = strategicObjectivesService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<StrategicObjectives>> GetStrategicObjectivess()
        {
            return strategicObjectivesService.GetStrategicObjectivess();
        }

        // GET: api/Projects/5
        [HttpGet("{id}")]
        public ActionResult<StrategicObjectives> GetStrategicObjectives(Guid id)
        {
            try
            {
                return strategicObjectivesService.GetStrategicObjectives(id);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        // PUT: api/Projects/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public StrategicObjectives PutStrategicObjectives(Guid id, StrategicObjectives strategicObjectives)
        {
            try
            {
                return strategicObjectivesService.UpdateStrategicObjectives(id, strategicObjectives);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        // POST: api/Projects
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public ActionResult<StrategicObjectives> PostStrategicObjectives(StrategicObjectives strategicObjectives)
        {
            try
            {
                return strategicObjectivesService.AddStrategicObjectives(strategicObjectives);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        // DELETE: api/Projects/5
        [HttpDelete("{id}")]
        public void DeleteStrategicObjectives(Guid id)
        {
            try
            {
                strategicObjectivesService.DeleteStrategicObjectives(id);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
