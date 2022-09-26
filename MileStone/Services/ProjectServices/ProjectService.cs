using Microsoft.EntityFrameworkCore;
using MileStone.Context;
using MileStone.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MileStone.Services.ProjectServices
{
    public class ProjectService : IProjectServicecs
    {
        private readonly DBContext context;
        public ProjectService(DBContext context)
        {
            this.context = context;
        }
        public Project AddProject(Project project)
        {
            if(project == null)
            {
                throw new NotImplementedException();

            }
            else
            {
                context.Projects.Add(project);
                context.SaveChanges();
                return project;
            }
        }

        public void DeleteProject(Guid Id)
        {
            var project = context.Projects.FirstOrDefault(e=>e.ProjectId == Id);
            if (project == null)
            {
                throw new NotImplementedException();

            }
            else
            {
                context.Projects.Remove(project);
                context.SaveChanges();
            }
        }

        public Project GetProject(Guid Id)
        {
            var project = context.Projects.Include(e => e.BusinessCasesWihtProjects).ThenInclude(s => s.BusinessCase).FirstOrDefault(t => t.ProjectId == Id);
            if(project == null)
            {
                throw new NotImplementedException();

            }
            else
            {
                return project;
            }
        }

        public List<Project> GetProjects()
        {
            return context.Projects.Include(e=>e.BusinessCasesWihtProjects).ThenInclude(s => s.BusinessCase).ToList();
        }

        public Project UpdateProject(Guid Id, Project project)
        {
            if (Id != project.ProjectId)
            {
                throw new NotImplementedException();

            }
            else
            {
                context.Entry(project).State = EntityState.Modified;
                context.SaveChanges();
                return project;
            }
        }
    }
}
