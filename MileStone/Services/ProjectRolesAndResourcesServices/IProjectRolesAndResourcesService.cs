using MileStone.Models;
using System;
using System.Collections.Generic;

namespace MileStone.Services.ProjectRolesAndResourcesServices
{
    public interface IProjectRolesAndResourcesService
    {
        public List<ProjectRolesAndResources> GetProjectRolesAndResourcess();
        public ProjectRolesAndResources GetProjectRolesAndResources(Guid Id);
        public ProjectRolesAndResources AddProjectRolesAndResources(ProjectRolesAndResources projectRolesAndResources);
        public ProjectRolesAndResources UpdateProjectRolesAndResourcesBusinessCase(Guid Id, ProjectRolesAndResources projectRolesAndResources);
        public void DeleteProjectRolesAndResourcesBusinessCase(Guid Id);
    }
}
