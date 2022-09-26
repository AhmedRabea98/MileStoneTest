using MileStone.Models;
using System;
using System.Collections.Generic;

namespace MileStone.Services.CommunicationPlanServices
{ 
public interface ICommunicationPlanService
{
        public List<CommunicationPlan> GetCommunicationPlans();
        public CommunicationPlan GetCommunicationPlan(Guid Id);
        public CommunicationPlan AddCommunicationPlan(CommunicationPlan communicationPlan);
        public CommunicationPlan UpdateCommunicationPlan(Guid Id, CommunicationPlan communicationPlan);
        public void DeleteCommunicationPlan(Guid Id);
    }
}
