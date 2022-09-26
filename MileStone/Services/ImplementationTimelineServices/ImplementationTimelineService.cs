using Microsoft.EntityFrameworkCore;
using MileStone.Context;
using MileStone.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MileStone.Services.ImplementationTimelineServices
{
    public class ImplementationTimelineService : IImplementationTimelineService
    {
        private readonly DBContext context;
        public ImplementationTimelineService(DBContext context)
        {
            this.context = context;
        }
        public ImplementationTimeline AddImplementationTimeline(ImplementationTimeline implementationTimeline)
        {
            if (implementationTimeline == null)
            {
                throw new NotImplementedException();


            }
            else
            {
                context.ImplementationTimeline.Add(implementationTimeline);
                context.SaveChanges();
                return implementationTimeline;
            }
        }

        public void DeleteImplementationTimeline(Guid Id)
        {
            var ImplementationTimeline = context.ImplementationTimeline.FirstOrDefault(e => e.ImplementationTimelineId == Id);
            if (ImplementationTimeline == null)
            {
                throw new NotImplementedException();

            }
            else
            {
               context.ImplementationTimeline.Remove(ImplementationTimeline);
                context.SaveChanges();
            }
        }

        public ImplementationTimeline GetImplementationTimeline(Guid Id)
        {
            var ImplementationTimeline = context.ImplementationTimeline.FirstOrDefault(e => e.ImplementationTimelineId == Id);
            if (ImplementationTimeline == null)
            {
                throw new NotImplementedException();

            }
            else
            {
                return ImplementationTimeline;
            }
        }

        public List<ImplementationTimeline> GetImplementationTimelines()
        {
            return context.ImplementationTimeline.ToList();
        }

        public ImplementationTimeline UpdateImplementationTimeline(Guid Id, ImplementationTimeline implementationTimeline)
        {
            if (Id != implementationTimeline.ImplementationTimelineId)
            {
                throw new NotImplementedException();

            }
            else
            {
                context.Entry(implementationTimeline).State = EntityState.Modified;
                context.SaveChanges();
                return implementationTimeline;
            }
        }
    }
    }

