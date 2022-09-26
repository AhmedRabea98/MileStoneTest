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
using MileStone.Services.ProjectCashFlowServices;

namespace MileStone.Controllers.ProjectCashFlowController
{
   // [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectCashFlowsController : ControllerBase
    {
        private readonly IProjectCashFlowService projectCashFlowService;

        public ProjectCashFlowsController(IProjectCashFlowService projectCashFlowService)
        {
            this.projectCashFlowService = projectCashFlowService;
        }

        // GET: api/ProjectCashFlows
        [HttpGet]
        public ActionResult<IEnumerable<ProjectCashFlow>> GetProjectCashFlow()
        {
            return projectCashFlowService.GetProjectCashFlows();
        }

        // GET: api/ProjectCashFlows/5
        [HttpGet("{id}")]
        public ActionResult<ProjectCashFlow> GetProjectCashFlow(Guid id)
        {
            try
            {
                return projectCashFlowService.GetProjectCashFlow(id);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        // PUT: api/ProjectCashFlows/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public ProjectCashFlow PutProjectCashFlow(Guid id, ProjectCashFlow projectCashFlow)
        {
            try
            {
                return projectCashFlowService.UpdateProjectCashFlow(id,projectCashFlow);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        // POST: api/ProjectCashFlows
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public ActionResult<ProjectCashFlow> PostProjectCashFlow(ProjectCashFlow projectCashFlow)
        {
            try
            {
                return projectCashFlowService.AddProjectCashFlow(projectCashFlow);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        // DELETE: api/ProjectCashFlows/5
        [HttpDelete("{id}")]
        public void DeleteProjectCashFlow(Guid id)
        {
            try
            {
                projectCashFlowService.DeleteProjectCashFlow(id);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

      
    }
}
