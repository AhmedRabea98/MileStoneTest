using MileStone.Models;
using System;
using System.Collections.Generic;

namespace MileStone.Services.ProjectServices
{
    public interface IProjectServicecs
    {
        public List<Project> GetProjects();
        public Project GetProject(Guid Id);
        public Project AddProject(Project project);
        public Project UpdateProject(Guid Id, Project project);
        public void DeleteProject(Guid Id);
    }
}
