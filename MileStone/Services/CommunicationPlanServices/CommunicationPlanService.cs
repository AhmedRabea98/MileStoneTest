using Microsoft.EntityFrameworkCore;
using MileStone.Context;
using MileStone.Models;
using MileStone.Services.CommentServices;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MileStone.Services.CommunicationPlanServices
{
    public class CommunicationPlanService : ICommunicationPlanService
    {
        private readonly DBContext context;
        public CommunicationPlanService(DBContext context)
        {
            this.context = context;
        }
        public CommunicationPlan AddCommunicationPlan(CommunicationPlan communicationPlan)
        {
            if (communicationPlan == null)
            {
                throw new NotImplementedException();


            }
            else
            {
                context.CommunicationPlans.Add(communicationPlan);
                context.SaveChanges();
                return communicationPlan;
            }
        }

        public void DeleteCommunicationPlan(Guid Id)
        {
            var communicationPlan = context.CommunicationPlans.FirstOrDefault(e => e.CommunicationPlanId == Id);
            if (communicationPlan == null)
            {
                throw new NotImplementedException();

            }
            context.CommunicationPlans.Remove(communicationPlan);
            context.SaveChanges();
        }

        public CommunicationPlan GetCommunicationPlan(Guid Id)
        {
            var communicationPlan = context.CommunicationPlans.FirstOrDefault(e => e.CommunicationPlanId == Id);
            if (communicationPlan == null)
            {
                throw new NotImplementedException();

            }
            else
            {
                return communicationPlan;
            }
        }

        public List<CommunicationPlan> GetCommunicationPlans()
        {
            return context.CommunicationPlans.ToList();
        }

        public CommunicationPlan UpdateCommunicationPlan(Guid Id, CommunicationPlan communicationPlan)
        {
            if (Id != communicationPlan.CommunicationPlanId)
            {
                throw new NotImplementedException();

            }
            else
            {
                context.Entry(communicationPlan).State = EntityState.Modified;
                context.SaveChanges();
                return communicationPlan;
            }
        }
    }
}
