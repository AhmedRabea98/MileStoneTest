using MileStone.Models;
using System;
using System.Collections.Generic;

namespace MileStone.Services.LimitationsAndAssumptionsServices
{
    public interface ILimitationsAndAssumptionsService
    {
        public List<LimitationsAndAssumptions> GetLimitationsAndAssumptions();
        public LimitationsAndAssumptions GetLimitationsAndAssumptions(Guid Id);
        public LimitationsAndAssumptions AddLimitationsAndAssumptions(LimitationsAndAssumptions limitationsAndAssumptions);
        public LimitationsAndAssumptions UpdateLimitationsAndAssumptions(Guid Id, LimitationsAndAssumptions limitationsAndAssumptions);
        public void DeleteLimitationsAndAssumptions(Guid Id);
    }
}
