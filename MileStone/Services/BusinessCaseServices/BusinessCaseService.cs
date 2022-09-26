using Microsoft.EntityFrameworkCore;
using MileStone.Context;
using MileStone.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MileStone.Services.BusinessCaseServices
{
    public class BusinessCaseService : IBusinessCaseService
    {
        private readonly DBContext context;
        public BusinessCaseService(DBContext context)
        {
            this.context = context;
        }
        public BusinessCase AddBusinessCase(BusinessCase businessCase)
        {
            if (businessCase == null)
            {
                throw new NotImplementedException();
            }
            else
            {
                NullCheck(businessCase);
                context.BusinessCases.Add(businessCase);
                context.SaveChanges();
                return businessCase;
            }
        }

        public void DeleteBusinessCase(Guid Id)
        {
            var businesscse = context.BusinessCases.FirstOrDefault(e => e.BusinessCaseID == Id);
            if (businesscse != null)
            {
                context.BusinessCases.Remove(businesscse);
                context.SaveChanges();
            }
            else
            {
                throw new NotImplementedException();

            }
        }

        public List<BusinessCase> GetBusinessCase()
        {
            List<BusinessCase> businessCases = new List<BusinessCase>();
            businessCases =  context.BusinessCases.Include(e => e.Sector).Include(e => e.Department).
                Include(e => e.Comments).Include(e => e.BeneficiariesandStakeholders).Include(e => e.Risks).Include(e=>e.Attachments)
                .Include(e => e.BusinessCasesWihtProjects).ThenInclude(s => s.Project).Include(e => e.ProjectCashFlows).ToList();

            foreach (var b in businessCases)
            {
                b.Sector.BusinessCases = new List<BusinessCase>();
                b.Department.BusinessCases = new List<BusinessCase>();
                b.Attachments = context.Attachment.Where(e => e.RelatedItemUID == b.BusinessCaseID).ToList();
                foreach (var c in b.BusinessCasesWihtProjects)
                {
                    c.Project.BusinessCasesWihtProjects = new List<BusinessCaseWithProjects>();

                }
                foreach(var a in b.Attachments)
                {
                    a.PhysicalPath = "Not Allowed";
                    a.Document = null;

                }

            }
            return businessCases;
        }

        public BusinessCase GetBusinessCase(Guid Id)
        {
            var businesscse = context.BusinessCases.Include(e => e.Sector).Include(e => e.Department).
                Include(e => e.Comments).Include(e => e.BeneficiariesandStakeholders).Include(e => e.Risks)
                .Include(e => e.Attachments)
                .Include(e => e.BusinessCasesWihtProjects).ThenInclude(s => s.Project).Include(e => e.ProjectCashFlows).FirstOrDefault(e => e.BusinessCaseID == Id);
            businesscse.Attachments = context.Attachment.Where(t=>t.RelatedItemUID ==Id).ToList();
            foreach(var a in businesscse.Attachments)
            {
                a.PhysicalPath = "Not Allowed";
                a.Document = null;
            }
            if (businesscse != null)
            {
                return businesscse;

            }
            else
            {
                throw new NotImplementedException();
            }
        }

        public BusinessCase UpdateBusinessCase(Guid Id, BusinessCase businessCase)
        {
            if (Id != businessCase.BusinessCaseID)
            {
                throw new NotImplementedException();
            }
            else
            {
                context.Entry(businessCase).State = EntityState.Modified;
                context.SaveChanges();
                return businessCase;
            }
        }

        protected BusinessCase NullCheck(BusinessCase businessCase)
        {
            if(businessCase.ExpectedDuration.ToString()== "")
            {
                businessCase.ExpectedDuration = DateTime.MinValue;
            }
            if(businessCase.ExpectedStartDate.ToString()== "")
            {
                businessCase.ExpectedStartDate = DateTime.MinValue;
            }
            return businessCase;
        }
    }
}
