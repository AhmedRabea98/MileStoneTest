using Microsoft.EntityFrameworkCore;
using MileStone.Context;
using MileStone.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MileStone.Services.ProjectRolesAndResourcesServices
{
    public class ProjectRolesAndResourcesService : IProjectRolesAndResourcesService
    {
        private readonly DBContext context;
        public ProjectRolesAndResourcesService(DBContext context)
        {
            this.context = context;
        }
        public ProjectRolesAndResources AddProjectRolesAndResources(ProjectRolesAndResources projectRolesAndResources)
        {
            if (projectRolesAndResources == null)
            {
                throw new NotImplementedException();
            }
            else
            {
                
                context.ProjectRolesAndResources.Add(projectRolesAndResources);
                context.SaveChanges();
                return projectRolesAndResources;
            }
        }

        public void DeleteProjectRolesAndResourcesBusinessCase(Guid Id)
        {
            var ProjectRolesAndResources = context.ProjectRolesAndResources.FirstOrDefault(e => e.ProjectRolesandResourcesId == Id);
            if (ProjectRolesAndResources != null)
            {
                context.ProjectRolesAndResources.Remove(ProjectRolesAndResources);
                context.SaveChanges();
            }
            else
            {
                throw new NotImplementedException();

            }
        }

        public ProjectRolesAndResources GetProjectRolesAndResources(Guid Id)
        {
            var ProjectRolesAndResources = context.ProjectRolesAndResources.Include(e=>e.ProjectCharter).FirstOrDefault(e => e.ProjectRolesandResourcesId == Id);
            if (ProjectRolesAndResources != null)
            {
                return ProjectRolesAndResources;
            }
            else
            {
                throw new NotImplementedException();

            }
        }

        public List<ProjectRolesAndResources> GetProjectRolesAndResourcess()
        {
            List<ProjectRolesAndResources> projectRolesAndResources = new List<ProjectRolesAndResources>();
            projectRolesAndResources = context.ProjectRolesAndResources.Include(e => e.ProjectCharter).ToList();
            if (projectRolesAndResources != null)
            {
                return projectRolesAndResources;
            }
            else
            {
                throw new NotImplementedException();

            }
        }

        public ProjectRolesAndResources UpdateProjectRolesAndResourcesBusinessCase(Guid Id, ProjectRolesAndResources projectRolesAndResources)
        {
            if (Id != projectRolesAndResources.ProjectRolesandResourcesId)
            {
                throw new NotImplementedException();
            }
            else
            {
                context.Entry(projectRolesAndResources).State = EntityState.Modified;
                context.SaveChanges();
                return projectRolesAndResources;
            }
        }
    }
}
