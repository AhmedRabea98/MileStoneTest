
using Microsoft.EntityFrameworkCore;
using MileStone.Context;
using MileStone.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MileStone.Services.ProjectCharterServices
{
    public class ProjectCharterService : IProjectCharterService
    {
        private readonly DBContext context;
        public ProjectCharterService(DBContext context)
        {
            this.context = context;                
        }
        public ProjectCharter AddProjectCharter(ProjectCharter projectCharter)
        {
            if(projectCharter == null)
            {
                throw new NotImplementedException();

            }
            else
            {
                NullCheck(projectCharter);
                context.ProjectCharters.Add(projectCharter);
                context.SaveChanges();
                return projectCharter;
            }
        }

        public void DeleteProjectCharter(Guid Id)
        {
            var ProjectCharter = context.ProjectCharters.FirstOrDefault(e=>e.ProjectCharterId == Id);
            if(ProjectCharter == null)
            {
                throw new NotImplementedException();

            }
            else
            {
                context.ProjectCharters.Remove(ProjectCharter);
                context.SaveChanges();
            }
        }

        public ProjectCharter GetProjectCharter(Guid Id)
        {
            var ProjectCharter = context.ProjectCharters.Include(e => e.Sector).Include(e=>e.Risks).Include(e=>e.StrategicObjectives)
                .Include(e=>e.Comments).Include(e=>e.Attachments).Include(e=>e.BeneficiariesandStakeholders).Include(
                e=>e.ProjectRolesAndResources).FirstOrDefault(e => e.ProjectCharterId == Id);
            ProjectCharter.Attachments = context.Attachment.Where(s=> s.RelatedItemUID == Id).ToList();

            foreach (var a in ProjectCharter.Attachments)
              {

                a.PhysicalPath = "Not Allowed";
                a.Document = null;
              }
            if (ProjectCharter == null)
            {
                throw new Exception();
            }
            else
            {
                return ProjectCharter;
            }
        }

        public List<ProjectCharter> GetProjectCharters()
        {
            List<ProjectCharter> projectCharters = new List<ProjectCharter>();
            projectCharters = context.ProjectCharters.Include(e => e.Sector).Include(e => e.Risks).Include(e => e.StrategicObjectives)
                .Include(e => e.Comments).Include(e => e.Attachments).Include(e => e.BeneficiariesandStakeholders).Include(
                e => e.ProjectRolesAndResources).ToList();

            foreach(var project in projectCharters)
            {
                project.Attachments = context.Attachment.Where(e => e.RelatedItemUID == project.ProjectCharterId).ToList();

                foreach (var a in project.Attachments)
                {
                    a.PhysicalPath = "Not Allowed";
                    a.Document = null;
                }
               
            }
            return projectCharters;
        }

        public ProjectCharter UpdateProjectCharter(Guid Id, ProjectCharter projectCharter)
        {
            if (Id != projectCharter.ProjectCharterId)
            {
                throw new NotImplementedException();
            }
            else
            {
                context.Entry(projectCharter).State = EntityState.Modified;
                context.SaveChanges();
                return projectCharter;
            }
        }

        protected ProjectCharter NullCheck(ProjectCharter projectCharter)
        {
            if (projectCharter.StartDate.ToString() == "")
            {
                projectCharter.StartDate = DateTime.MinValue;
            }
            if (projectCharter.FinishDate.ToString() == "")
            {
                projectCharter.FinishDate = DateTime.MinValue;
            }
            return projectCharter;
        }
    }
}
