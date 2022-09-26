using Microsoft.EntityFrameworkCore;
using MileStone.Context;
using MileStone.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MileStone.Services.ProjectOutputsAndCostServices
{
    public class ProjectOutputsAndCostService : IProjectOutputsAndCostService
    {
        private readonly DBContext context;
        public ProjectOutputsAndCostService(DBContext context)
        {
            this.context = context;
        }
        public ProjectOutputsAndCost AddProjectOutputsAndCost(ProjectOutputsAndCost projectOutputsAndCost)
        {
            if (projectOutputsAndCost == null)
            {
                throw new NotImplementedException();


            }
            else
            {
                context.ProjectOutputsAndCosts.Add(projectOutputsAndCost);
                context.SaveChanges();
                return projectOutputsAndCost;
            }

        }

        public void DeleteProjectOutputsAndCost(Guid Id)
        {
            var ProjectOutputsAndCost = context.ProjectOutputsAndCosts.FirstOrDefault(e => e.ProjectOutputsAndCostId == Id);
            if (ProjectOutputsAndCost == null)
            {
                throw new NotImplementedException();

            }
            else
            {
                context.ProjectOutputsAndCosts.Remove(ProjectOutputsAndCost);
                context.SaveChanges();
            }
        }

        public ProjectOutputsAndCost GetProjectOutputsAndCost(Guid Id)
        {
            var ProjectOutputsAndCost = context.ProjectOutputsAndCosts.FirstOrDefault(e => e.ProjectOutputsAndCostId == Id);
            if (ProjectOutputsAndCost == null)
            {
                throw new NotImplementedException();

            }
            else
            {
                return ProjectOutputsAndCost;
            }
        }

        public List<ProjectOutputsAndCost> GetProjectOutputsAndCosts()
        {
            return context.ProjectOutputsAndCosts.ToList();
        }

        public ProjectOutputsAndCost UpdateProjectOutputsAndCost(Guid Id, ProjectOutputsAndCost projectOutputsAndCost)
        {
            if (Id != projectOutputsAndCost.ProjectOutputsAndCostId)
            {
                throw new NotImplementedException();

            }
            else
            {
                context.Entry(projectOutputsAndCost).State = EntityState.Modified;
                context.SaveChanges();
                return projectOutputsAndCost;
            }
        }
    }
    }

