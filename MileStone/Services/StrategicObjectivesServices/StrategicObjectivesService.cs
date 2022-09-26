using Microsoft.EntityFrameworkCore;
using MileStone.Context;
using MileStone.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MileStone.Services.StrategicObjectivesServices
{
    public class StrategicObjectivesService : IStrategicObjectivesService
    {
        private readonly DBContext context;
        public StrategicObjectivesService(DBContext context)
        {
            this.context = context;
        }
        public StrategicObjectives AddStrategicObjectives(StrategicObjectives strategicObjectives)
        {
            if (strategicObjectives == null)
            {
                throw new NotImplementedException();
            }
            else
            {
                context.StrategicObjectives.Add(strategicObjectives);
                context.SaveChanges();
                return strategicObjectives;
            }
        }

        public void DeleteStrategicObjectives(Guid Id)
        {
            var strategicObjective = context.StrategicObjectives.FirstOrDefault(e => e.StrategicObjectivesId == Id);
            if (strategicObjective != null)
            {
                context.StrategicObjectives.Remove(strategicObjective);
                context.SaveChanges();
            }
            else
            {
                throw new NotImplementedException();

            }
        }

        public StrategicObjectives GetStrategicObjectives(Guid Id)
        {
            var strategicObjective = context.StrategicObjectives.Include(e=>e.ProjectCharter)
                .Include(e=>e.ProjectManagementPlan).FirstOrDefault(s => s.StrategicObjectivesId == Id);
            if (strategicObjective != null)
            {
                return strategicObjective;
            }
            else
            {
                throw new NotImplementedException();

            }
        }

        public List<StrategicObjectives> GetStrategicObjectivess()
        {
            List<StrategicObjectives> strategicObjectives = new List<StrategicObjectives>();
             strategicObjectives = context.StrategicObjectives.Include(e => e.ProjectCharter).Include(e=>e.ProjectManagementPlan).ToList();
                return strategicObjectives;
           
        }

        public StrategicObjectives UpdateStrategicObjectives(Guid Id, StrategicObjectives strategicObjectives)
        {
            if (Id != strategicObjectives.StrategicObjectivesId)
            {
                throw new NotImplementedException();
            }
            else
            {
                context.Entry(strategicObjectives).State = EntityState.Modified;
                context.SaveChanges();
                return strategicObjectives;
            }
        }
    }
}
