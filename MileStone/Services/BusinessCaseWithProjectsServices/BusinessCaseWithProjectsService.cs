using Microsoft.EntityFrameworkCore;
using MileStone.Context;
using MileStone.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MileStone.Services.BusinessCaseWithProjectsServices
{
    public class BusinessCaseWithProjectsService : IBusinessCaseWithProjectsService
    {
        private readonly DBContext context;
        public BusinessCaseWithProjectsService(DBContext context)
        {
            this.context = context;
        }
        public BusinessCaseWithProjects AddBusinessCaseWithProject(BusinessCaseWithProjects businessCaseWithProject)
        {
            if(businessCaseWithProject == null)
            {
                throw new NotImplementedException();
            }
            else
            {
                context.BusinessCaseWithProjects.Add(businessCaseWithProject);
                context.SaveChanges();
                return businessCaseWithProject;
            }
        }

        public void DeleteBusinessCaseWithProject(Guid Id)
        {
            var bcwp = context.BusinessCaseWithProjects.FirstOrDefault(e => e.BusienssCaseID == Id);
            if (bcwp != null)
            {
                context.BusinessCaseWithProjects.Remove(bcwp);
                context.SaveChanges();

            }
            else
            {
                throw new NotImplementedException();
            }
        }

        public BusinessCaseWithProjects GetBusinessCaseWithProject(Guid Id)
        {
            var bcwp = context.BusinessCaseWithProjects.FirstOrDefault(e => e.BusienssCaseID == Id);
            if (bcwp != null)
            {
                return bcwp;

            }
            else
            {
                throw new NotImplementedException();
            }
        }

        public List<BusinessCaseWithProjects> GetBusinessCaseWithProjects()
        {
            return context.BusinessCaseWithProjects.ToList();
        }

        public BusinessCaseWithProjects UpdateBusinessCaseWithProject(Guid Id, BusinessCaseWithProjects businessCaseWithProject)
        {
            if (Id != businessCaseWithProject.ProjectID)
            {
                throw new NotImplementedException();

            }
            else
            {
                context.Entry(businessCaseWithProject).State = EntityState.Modified;
                context.SaveChanges();
                return businessCaseWithProject;
            }
        }
    }
}
