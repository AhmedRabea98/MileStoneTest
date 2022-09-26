using Microsoft.EntityFrameworkCore;
using MileStone.Context;
using MileStone.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MileStone.Services.ProjectManagementPlanServices
{
    public class ProjectManagementPlanService : IProjectManagementPlanService
    {
        private readonly DBContext Context;
        public ProjectManagementPlanService(DBContext context)
        {
            this.Context = context;
        }
        public ProjectManagementPlan AddProjectManagementPlan(ProjectManagementPlan projectManagementPlan)
        {
            if (projectManagementPlan == null)
            {
                throw new NotImplementedException();
            }
            else
            {
                NullCheck(projectManagementPlan);
                Context.ProjectManagementPlans.Add(projectManagementPlan);
                Context.SaveChanges();
                return projectManagementPlan;
            }
        }

        public void DeleteProjectManagementPlan(Guid Id)
        {
            var projectManagementPlan = Context.ProjectManagementPlans.FirstOrDefault(e => e.ProjectManagementPlanId == Id);
            if (projectManagementPlan != null)
            {
                Context.ProjectManagementPlans.Remove(projectManagementPlan);
                Context.SaveChanges();
            }
            else
            {
                throw new NotImplementedException();
            }
        }

        public List<ProjectManagementPlan> GetProjectManagementPlans()
        {
            List<ProjectManagementPlan> projectManagementPlans = new List<ProjectManagementPlan>();
            projectManagementPlans = Context.ProjectManagementPlans.Include(e=>e.Sector).Include(e=>e.Attachments)
                .Include(e=>e.StrategicObjectsives).Include(e=>e.ProjectOutputsAndCosts).Include(e=>e.Risks)
                .Include(e=>e.ImplementationTimelines).Include(e=>e.LimitationsAndAssumptions).Include(e=>e.ResourceAndCadreManagement)
                .Include(e=>e.BeneficiariesandStakeholders).Include(e=>e.ProjectRolesAndResources).Include(e=>e.CommunicationPlans)
                .Include(e=>e.BenefitRealizationPlans).Include(e=>e.Comments).ToList();
            foreach (var project in projectManagementPlans)
            {
                project.Attachments = Context.Attachment.Where(e => e.RelatedItemUID == project.ProjectManagementPlanId).ToList();

                foreach (var a in project.Attachments)
                {
                    a.PhysicalPath = "Not Allowed";
                    a.Document = null;
                }

            }

            return projectManagementPlans;
        }

        public ProjectManagementPlan GetProjectManagementPlan(Guid Id)
        {
            var projectManagementPlans = Context.ProjectManagementPlans.Include(e => e.Sector).Include(e => e.Attachments)
                 .Include(e => e.StrategicObjectsives).Include(e => e.ProjectOutputsAndCosts).Include(e => e.Risks)
                 .Include(e => e.ImplementationTimelines).Include(e => e.LimitationsAndAssumptions).Include(e => e.ResourceAndCadreManagement)
                 .Include(e => e.BeneficiariesandStakeholders).Include(e => e.ProjectRolesAndResources).Include(e => e.CommunicationPlans)
                 .Include(e => e.BenefitRealizationPlans).Include(e=>e.Comments).FirstOrDefault(s=>s.ProjectManagementPlanId == Id);
            projectManagementPlans.Attachments = Context.Attachment.Where(e=> e.RelatedItemUID == Id).ToList();
            foreach (var a in projectManagementPlans.Attachments)
            {

                a.PhysicalPath = "Not Allowed";
                a.Document = null;
            }
            if(projectManagementPlans == null)
            {
                throw new NotImplementedException();

            }
            else
            {
                return projectManagementPlans;
            }
        }

        public ProjectManagementPlan UpdateProjectManagementPlan(Guid Id, ProjectManagementPlan projectManagementPlan)
        {
            if (Id != projectManagementPlan.ProjectManagementPlanId)
            {
                throw new NotImplementedException();
            }
            else
            {
                Context.Entry(projectManagementPlan).State = EntityState.Modified;
                Context.SaveChanges();
                return projectManagementPlan;
            }
        }


        protected ProjectManagementPlan NullCheck(ProjectManagementPlan projectManagementPlan)
        {
            if (projectManagementPlan.PlannedStartDate.ToString() == "")
            {
                projectManagementPlan.PlannedStartDate = DateTime.MinValue;
            }
            if (projectManagementPlan.PlannedFinishDate.ToString() == "")
            {
                projectManagementPlan.PlannedFinishDate = DateTime.MinValue;
            }
            return projectManagementPlan;
        }
    }
}
