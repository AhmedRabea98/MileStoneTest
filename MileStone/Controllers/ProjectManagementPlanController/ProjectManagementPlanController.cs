using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MileStone.Models;
using MileStone.Services.ProjectManagementPlanServices;
using System;
using System.Collections.Generic;

namespace MileStone.Controllers.ProjectManagementPlanController
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectManagementPlanController : ControllerBase
    {
        private readonly IProjectManagementPlanService ProjectManagementPlanService;
        public ProjectManagementPlanController(IProjectManagementPlanService ProjectManagementPlanService)
        {
            this.ProjectManagementPlanService = ProjectManagementPlanService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<ProjectManagementPlan>> GetProjectManagementPlans()
        {
            return ProjectManagementPlanService.GetProjectManagementPlans();
        }

        // GET: api/BusinessCases/5
        [HttpGet("{id}")]
        public ActionResult<ProjectManagementPlan> GetProjectManagementPlan(Guid id)
        {
            try
            {
                return ProjectManagementPlanService.GetProjectManagementPlan(id);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        // PUT: api/BusinessCases/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public ProjectManagementPlan PutProjectManagementPlan(Guid id, ProjectManagementPlan projectManagementPlan)
        {
            try
            {
                return ProjectManagementPlanService.UpdateProjectManagementPlan(id, projectManagementPlan);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }

        // POST: api/BusinessCases
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [Route("AddProjectManagementPlan")]
        [HttpPost]
        public ActionResult<ProjectManagementPlan> PostProjectManagementPlan(ProjectManagementPlan projectManagementPlan)
        {
            try
            {
                return ProjectManagementPlanService.AddProjectManagementPlan(projectManagementPlan);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }

        // DELETE: api/BusinessCases/5
        [HttpDelete("{id}")]
        public void DeleteProjectManagementPlan(Guid id)
        {
            try
            {
                ProjectManagementPlanService.DeleteProjectManagementPlan(id);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
