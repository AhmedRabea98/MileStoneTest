using MileStone.Models;
using System;
using System.Collections.Generic;

namespace MileStone.Services.RisksServices
{
    public interface IRisksService
    {
        public List<Risk> GetRisks();
        public Risk GetRisk(Guid Id);
        public Risk AddRisk(Risk risk);
        public Risk UpdateRisk(Guid Id, Risk risk);
        public void DeleteRisk(Guid Id);
    }
}
