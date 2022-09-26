using Microsoft.EntityFrameworkCore;
using MileStone.Context;
using MileStone.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MileStone.Services.LimitationsAndAssumptionsServices
{
    public class LimitationsAndAssumptionsService : ILimitationsAndAssumptionsService
    {
        private readonly DBContext context;
        public LimitationsAndAssumptionsService(DBContext context)
        {
            this.context = context;
        }
        public LimitationsAndAssumptions AddLimitationsAndAssumptions(LimitationsAndAssumptions limitationsAndAssumptions)
        {
            if (limitationsAndAssumptions == null)
            {
                throw new NotImplementedException();


            }
            else
            {
                context.LimitationsAndAssumptions.Add(limitationsAndAssumptions);
                context.SaveChanges();
                return limitationsAndAssumptions;
            }
        }

        public void DeleteLimitationsAndAssumptions(Guid Id)
        {
            var LimitationsAndAssumptions = context.LimitationsAndAssumptions.FirstOrDefault(e => e.LimitationsAndAssumptionsId == Id);
            if (LimitationsAndAssumptions == null)
            {
                throw new NotImplementedException();

            }
            else
            {
              context.LimitationsAndAssumptions.Remove(LimitationsAndAssumptions);
                context.SaveChanges();
            }
        }

        public List<LimitationsAndAssumptions> GetLimitationsAndAssumptions()
        {
            return context.LimitationsAndAssumptions.ToList();

        }

        public LimitationsAndAssumptions GetLimitationsAndAssumptions(Guid Id)
        {
            var LimitationsAndAssumptions = context.LimitationsAndAssumptions.FirstOrDefault(e => e.LimitationsAndAssumptionsId == Id);
            if (LimitationsAndAssumptions == null)
            {
                throw new NotImplementedException();

            }
            else
            {
                return LimitationsAndAssumptions;
            }
        }

        public LimitationsAndAssumptions UpdateLimitationsAndAssumptions(Guid Id, LimitationsAndAssumptions limitationsAndAssumptions)
        {
            if (Id != limitationsAndAssumptions.LimitationsAndAssumptionsId)
            {
                throw new NotImplementedException();

            }
            else
            {
                context.Entry(limitationsAndAssumptions).State = EntityState.Modified;
                context.SaveChanges();
                return limitationsAndAssumptions;
            }
        }
    }
    }

