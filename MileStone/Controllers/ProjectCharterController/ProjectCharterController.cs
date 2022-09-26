using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MileStone.Models;
using MileStone.Services.ProjectCharterServices;
using System;
using System.Collections.Generic;

namespace MileStone.Controllers.ProjectCharterController
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectCharterController : ControllerBase
    {
        private readonly IProjectCharterService projectCharterService;
        public ProjectCharterController(IProjectCharterService projectCharterService)
        {
            this.projectCharterService = projectCharterService;
        }
        // GET: api/Projects
        [HttpGet]
        public ActionResult<IEnumerable<ProjectCharter>> GetProjectCharters()
        {
            return projectCharterService.GetProjectCharters();
        }

        // GET: api/Projects/5
        [HttpGet("{id}")]
        public ActionResult<ProjectCharter> GetProjectCharter(Guid id)
        {
            try
            {
                return projectCharterService.GetProjectCharter(id);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        // PUT: api/Projects/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public ProjectCharter PutProjectCharter(Guid id, ProjectCharter projectCharter)
        {
            try
            {
                return projectCharterService.UpdateProjectCharter(id, projectCharter);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        // POST: api/Projects
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [Route("AddProjectCharter")]
        [HttpPost]
        public ActionResult<ProjectCharter> PostProjectCharter(ProjectCharter projectCharter)
        {
            try
            {
                return projectCharterService.AddProjectCharter(projectCharter);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        // DELETE: api/Projects/5
        [HttpDelete("{id}")]
        public void DeleteProjectCharter(Guid id)
        {
            try
            {
                projectCharterService.DeleteProjectCharter(id);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
