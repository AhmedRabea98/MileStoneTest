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
using MileStone.Services.ProjectServices;

namespace MileStone.Controllers.ProjectController
{
   // [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectsController : ControllerBase
    {
        private readonly IProjectServicecs projectServicecs;

        public ProjectsController(IProjectServicecs projectServicecs)
        {
            this.projectServicecs = projectServicecs;
        }

        // GET: api/Projects
        [HttpGet]
        public ActionResult<IEnumerable<Project>> GetProjects()
        {
            return  projectServicecs.GetProjects();
        }

        // GET: api/Projects/5
        [HttpGet("{id}")]
        public ActionResult<Project> GetProject(Guid id)
        {
            try
            {
                return projectServicecs.GetProject(id);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        // PUT: api/Projects/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public Project PutProject(Guid id, Project project)
        {
            try
            {
                return projectServicecs.UpdateProject(id,project);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        // POST: api/Projects
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public ActionResult<Project> PostProject(Project project)
        {
            try
            {
                return projectServicecs.AddProject(project);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        // DELETE: api/Projects/5
        [HttpDelete("{id}")]
        public void DeleteProject(Guid id)
        {
            try
            {
                 projectServicecs.DeleteProject(id);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

       
    }
}
