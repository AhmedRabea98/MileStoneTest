using MileStone.Models;
using System;
using System.Collections.Generic;

namespace MileStone.Services.ImplementationTimelineServices
{
    public interface IImplementationTimelineService
    {
        public List<ImplementationTimeline> GetImplementationTimelines();
        public ImplementationTimeline GetImplementationTimeline(Guid Id);
        public ImplementationTimeline AddImplementationTimeline(ImplementationTimeline implementationTimeline);
        public ImplementationTimeline UpdateImplementationTimeline(Guid Id, ImplementationTimeline implementationTimeline);
        public void DeleteImplementationTimeline(Guid Id);
    }
}
