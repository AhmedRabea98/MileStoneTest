using MileStone.Models;
using System;
using System.Collections.Generic;

namespace MileStone.Services.ProjectOutputsAndCostServices
{
    public interface IProjectOutputsAndCostService
    {
        public List<ProjectOutputsAndCost> GetProjectOutputsAndCosts();
        public ProjectOutputsAndCost GetProjectOutputsAndCost(Guid Id);
        public ProjectOutputsAndCost AddProjectOutputsAndCost(ProjectOutputsAndCost projectOutputsAndCost);
        public ProjectOutputsAndCost UpdateProjectOutputsAndCost(Guid Id, ProjectOutputsAndCost projectOutputsAndCost);
        public void DeleteProjectOutputsAndCost(Guid Id);
    }
}
