using MileStone.Models;
using System;
using System.Collections.Generic;

namespace MileStone.Services.BusinessCaseServices
{
    public interface IBusinessCaseService
    {
        public List<BusinessCase> GetBusinessCase();
        public BusinessCase GetBusinessCase(Guid Id);
        public BusinessCase AddBusinessCase(BusinessCase businessCase);
        public BusinessCase UpdateBusinessCase(Guid Id, BusinessCase businessCase);
        public void DeleteBusinessCase(Guid Id);
    }
}
