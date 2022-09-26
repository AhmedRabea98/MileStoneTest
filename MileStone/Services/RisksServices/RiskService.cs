using Microsoft.EntityFrameworkCore;
using MileStone.Context;
using MileStone.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MileStone.Services.RisksServices
{
    public class RiskService : IRisksService
    {
        private readonly DBContext context;
        public RiskService(DBContext context)
        {
            this.context = context;
        }
        public Risk AddRisk(Risk risk)
        {
            if(risk == null)
            {
                throw new NotImplementedException();

            }
            else
            {
                context.Risks.Add(risk);
                context.SaveChanges();
                return risk;
            }
        }

        public void DeleteRisk(Guid Id)
        {
         var risk = context.Risks.Find(Id);
            if (risk == null)
            {
                throw new NotImplementedException();

            }
            else
            {
                context.Risks.Remove(risk);
                context.SaveChanges();
            }
        }

        public Risk GetRisk(Guid Id)
        {
            var risk = context.Risks.Find(Id);
           if (risk == null)
            {
                throw new NotImplementedException();

            }
            else
            {
                return risk;
            }
        }

        public List<Risk> GetRisks()
        {
            return context.Risks.ToList();
        }

        public Risk UpdateRisk(Guid Id, Risk risk)
        {
            if (Id != risk.RiskId)
            {
                throw new NotImplementedException();

            }
            else
            {
                context.Entry(risk).State = EntityState.Modified;
                context.SaveChanges();
                return risk;
            }
        }
    }
}
