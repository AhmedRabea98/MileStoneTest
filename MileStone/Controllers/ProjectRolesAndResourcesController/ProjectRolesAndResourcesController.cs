using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MileStone.Models;
using MileStone.Services.ProjectRolesAndResourcesServices;
using System;
using System.Collections.Generic;

namespace MileStone.Controllers.ProjectRolesAndResourcesController
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectRolesAndResourcesController : ControllerBase
    {
        private readonly IProjectRolesAndResourcesService projectRolesAndResourcesService;
        public ProjectRolesAndResourcesController(IProjectRolesAndResourcesService projectRolesAndResourcesService)
        {
            this.projectRolesAndResourcesService = projectRolesAndResourcesService;
        }
        [HttpGet]
        public ActionResult<IEnumerable<ProjectRolesAndResources>> GetProjectRolesAndResourcess()
        {
            return projectRolesAndResourcesService.GetProjectRolesAndResourcess();
        }

        // GET: api/Projects/5
        [HttpGet("{id}")]
        public ActionResult<ProjectRolesAndResources> GetProjectRolesAndResources(Guid id)
        {
            try
            {
                return projectRolesAndResourcesService.GetProjectRolesAndResources(id);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        // PUT: api/Projects/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public ProjectRolesAndResources PutProjectRolesAndResourcesBusinessCase(Guid id, ProjectRolesAndResources projectRolesAndResources)
        {
            try
            {
                return projectRolesAndResourcesService.UpdateProjectRolesAndResourcesBusinessCase(id, projectRolesAndResources);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        // POST: api/Projects
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public ActionResult<ProjectRolesAndResources> PostProjectRolesAndResources(ProjectRolesAndResources projectRolesAndResources)
        {
            try
            {
                return projectRolesAndResourcesService.AddProjectRolesAndResources(projectRolesAndResources);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        // DELETE: api/Projects/5
        [HttpDelete("{id}")]
        public void DeleteProjectRolesAndResourcesBusinessCase(Guid id)
        {
            try
            {
                projectRolesAndResourcesService.DeleteProjectRolesAndResourcesBusinessCase(id);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
