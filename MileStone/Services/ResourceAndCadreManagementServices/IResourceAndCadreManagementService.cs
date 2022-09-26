using MileStone.Models;
using System;
using System.Collections.Generic;

namespace MileStone.Services.ResourceAndCadreManagementServices
{
    public interface IResourceAndCadreManagementService
    {
        public List<ResourceAndCadreManagement> GetResourceAndCadreManagements();
        public ResourceAndCadreManagement GetResourceAndCadreManagement(Guid Id);
        public ResourceAndCadreManagement AddResourceAndCadreManagement(ResourceAndCadreManagement resourceAndCadreManagement);
        public ResourceAndCadreManagement UpdateResourceAndCadreManagement(Guid Id, ResourceAndCadreManagement resourceAndCadreManagement);
        public void DeleteResourceAndCadreManagement(Guid Id);
    }
}
