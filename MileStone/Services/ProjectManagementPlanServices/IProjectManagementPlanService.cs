using MileStone.Models;
using System;
using System.Collections.Generic;

namespace MileStone.Services.ProjectManagementPlanServices
{
    public interface IProjectManagementPlanService
    {
        public List<ProjectManagementPlan> GetProjectManagementPlans();
        public ProjectManagementPlan GetProjectManagementPlan(Guid Id);
        public ProjectManagementPlan AddProjectManagementPlan(ProjectManagementPlan projectManagementPlan);
        public ProjectManagementPlan UpdateProjectManagementPlan(Guid Id, ProjectManagementPlan projectManagementPlan);
        public void DeleteProjectManagementPlan(Guid Id);
    }
}
