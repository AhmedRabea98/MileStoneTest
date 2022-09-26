using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MileStone.Models;
using MileStone.Services.ProjectOutputsAndCostServices;
using System;
using System.Collections.Generic;

namespace MileStone.Controllers.ProjectOutputsAndCostController
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectOutputsAndCostController : ControllerBase
    {
        private readonly IProjectOutputsAndCostService projectOutputsAndCostService;
        public ProjectOutputsAndCostController(IProjectOutputsAndCostService projectOutputsAndCostService)
        {
            this.projectOutputsAndCostService = projectOutputsAndCostService;
        }
        [HttpGet]
        public ActionResult<IEnumerable<ProjectOutputsAndCost>> GetProjectOutputsAndCosts()
        {
            return projectOutputsAndCostService.GetProjectOutputsAndCosts();
        }

        // GET: api/BusinessCases/5
        [HttpGet("{id}")]
        public ActionResult<ProjectOutputsAndCost> GetProjectOutputsAndCost(Guid id)
        {
            try
            {
                return projectOutputsAndCostService.GetProjectOutputsAndCost(id);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        // PUT: api/BusinessCases/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public ProjectOutputsAndCost PutProjectOutputsAndCost(Guid id, ProjectOutputsAndCost projectOutputsAndCost)
        {
            try
            {
                return projectOutputsAndCostService.UpdateProjectOutputsAndCost(id, projectOutputsAndCost);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        // POST: api/BusinessCases
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public ActionResult<ProjectOutputsAndCost> PostProjectOutputsAndCost(ProjectOutputsAndCost projectOutputsAndCost)
        {
            try
            {
                return projectOutputsAndCostService.AddProjectOutputsAndCost(projectOutputsAndCost);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }

        // DELETE: api/BusinessCases/5
        [HttpDelete("{id}")]
        public void DeleteProjectOutputsAndCost(Guid id)
        {
            try
            {
                projectOutputsAndCostService.DeleteProjectOutputsAndCost(id);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
