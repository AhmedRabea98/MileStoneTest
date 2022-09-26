using MileStone.Models;
using System;
using System.Collections.Generic;

namespace MileStone.Services.ProjectCashFlowServices
{
    public interface IProjectCashFlowService
    {
        public List<ProjectCashFlow> GetProjectCashFlows();
        public ProjectCashFlow GetProjectCashFlow(Guid Id);
        public ProjectCashFlow AddProjectCashFlow(ProjectCashFlow projectCashFlow);
        public ProjectCashFlow UpdateProjectCashFlow(Guid Id, ProjectCashFlow projectCashFlow);
        public void DeleteProjectCashFlow(Guid Id);
    }
}
