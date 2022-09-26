using MileStone.Models;
using System;
using System.Collections.Generic;

namespace MileStone.Services.ProjectCharterServices
{
    public interface IProjectCharterService
    {
        public List<ProjectCharter> GetProjectCharters();
        public ProjectCharter GetProjectCharter(Guid Id);
        public ProjectCharter AddProjectCharter(ProjectCharter projectCharter);
        public ProjectCharter UpdateProjectCharter(Guid Id, ProjectCharter projectCharter);
        public void DeleteProjectCharter(Guid Id);
    }
}
