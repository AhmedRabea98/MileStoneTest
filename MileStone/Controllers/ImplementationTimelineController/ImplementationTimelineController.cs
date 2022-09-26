using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MileStone.Models;
using MileStone.Services.ImplementationTimelineServices;
using System;
using System.Collections.Generic;

namespace MileStone.Controllers.ImplementationTimelineController
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImplementationTimelineController : ControllerBase
    {
        private readonly IImplementationTimelineService implementationTimelineService;
        public ImplementationTimelineController(IImplementationTimelineService implementationTimelineService)
        {
            this.implementationTimelineService = implementationTimelineService;
        }
        [HttpGet]
        public ActionResult<IEnumerable<ImplementationTimeline>> GetImplementationTimelines()
        {
            return implementationTimelineService.GetImplementationTimelines();
        }

        // GET: api/BusinessCases/5
        [HttpGet("{id}")]
        public ActionResult<ImplementationTimeline> GetImplementationTimeline(Guid id)
        {
            try
            {
                return implementationTimelineService.GetImplementationTimeline(id);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        // PUT: api/BusinessCases/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public ImplementationTimeline PutImplementationTimeline(Guid id, ImplementationTimeline implementationTimeline)
        {
            try
            {
                return implementationTimelineService.UpdateImplementationTimeline(id, implementationTimeline);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        // POST: api/BusinessCases
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public ActionResult<ImplementationTimeline> PostImplementationTimeline(ImplementationTimeline implementationTimeline)
        {
            try
            {
                return implementationTimelineService.AddImplementationTimeline(implementationTimeline);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }

        // DELETE: api/BusinessCases/5
        [HttpDelete("{id}")]
        public void DeleteImplementationTimeline(Guid id)
        {
            try
            {
                implementationTimelineService.DeleteImplementationTimeline(id);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
