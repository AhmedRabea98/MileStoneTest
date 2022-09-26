using MileStone.Models;
using System;
using System.Collections.Generic;

namespace MileStone.Services.BusinessCaseWithProjectsServices
{
    public interface IBusinessCaseWithProjectsService
    {
        public List<BusinessCaseWithProjects> GetBusinessCaseWithProjects();
        public BusinessCaseWithProjects GetBusinessCaseWithProject(Guid Id);
        public BusinessCaseWithProjects AddBusinessCaseWithProject(BusinessCaseWithProjects businessCaseWithProject);
        public BusinessCaseWithProjects UpdateBusinessCaseWithProject(Guid Id, BusinessCaseWithProjects businessCaseWithProject);
        public void DeleteBusinessCaseWithProject(Guid Id);
    }
}
