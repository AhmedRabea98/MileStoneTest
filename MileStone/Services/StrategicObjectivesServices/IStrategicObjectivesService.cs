using MileStone.Models;
using System;
using System.Collections.Generic;

namespace MileStone.Services.StrategicObjectivesServices
{
    public interface IStrategicObjectivesService
    {
        public List<StrategicObjectives> GetStrategicObjectivess();
        public StrategicObjectives GetStrategicObjectives(Guid Id);
        public StrategicObjectives AddStrategicObjectives(StrategicObjectives strategicObjectives);
        public StrategicObjectives UpdateStrategicObjectives(Guid Id, StrategicObjectives strategicObjectives);
        public void DeleteStrategicObjectives(Guid Id);
    }
}
