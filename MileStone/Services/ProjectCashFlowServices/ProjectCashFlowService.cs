using Microsoft.EntityFrameworkCore;
using MileStone.Context;
using MileStone.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MileStone.Services.ProjectCashFlowServices
{
    public class ProjectCashFlowService : IProjectCashFlowService
    {
        private readonly DBContext context;
        public ProjectCashFlowService(DBContext context)
        {
            this.context = context;
        }
        public ProjectCashFlow AddProjectCashFlow(ProjectCashFlow projectCashFlow)
        {
           if(projectCashFlow == null)
            {
                throw new NotImplementedException();

            }
            else
            {
                context.ProjectCashFlows.Add(projectCashFlow);
                context.SaveChanges();
                return projectCashFlow;
            }
        }

        public void DeleteProjectCashFlow(Guid Id)
        {
            var project = context.ProjectCashFlows.FirstOrDefault(e => e.ProjectCashFlowId == Id);
            if (project == null)
            {
                throw new NotImplementedException();

            }
            else
            {
                context.ProjectCashFlows.Remove(project);
                context.SaveChanges();
            }
        }

        public ProjectCashFlow GetProjectCashFlow(Guid Id)
        {
            var project = context.ProjectCashFlows.FirstOrDefault(e => e.ProjectCashFlowId == Id);
            if (project == null)
            {
                throw new NotImplementedException();

            }
            else
            {
                return project;
            }
        }

        public List<ProjectCashFlow> GetProjectCashFlows()
        {
            return context.ProjectCashFlows.ToList();
        }

        public ProjectCashFlow UpdateProjectCashFlow(Guid Id, ProjectCashFlow projectCashFlow)
        {
            if (Id != projectCashFlow.ProjectCashFlowId)
            {
                throw new NotImplementedException();

            }
            else
            {
                context.Entry(projectCashFlow).State = EntityState.Modified;
                context.SaveChanges();
                return projectCashFlow;
            }
        }
    }
}
