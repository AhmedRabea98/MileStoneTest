using Microsoft.EntityFrameworkCore;
using MileStone.Context;
using MileStone.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MileStone.Services.ResourceAndCadreManagementServices
{
    public class ResourceAndCadreManagementService : IResourceAndCadreManagementService
    {
        private readonly DBContext context;
        public ResourceAndCadreManagementService(DBContext context)
        {
            this.context = context;
        }
        public ResourceAndCadreManagement AddResourceAndCadreManagement(ResourceAndCadreManagement resourceAndCadreManagement)
        {
            if (resourceAndCadreManagement == null)
            {
                throw new NotImplementedException();


            }
            else
            {
                context.ResourceAndCadreManagement.Add(resourceAndCadreManagement);
                context.SaveChanges();
                return resourceAndCadreManagement;
            }
        }

        public void DeleteResourceAndCadreManagement(Guid Id)
        {
            var ResourceAndCadreManagement = context.ResourceAndCadreManagement.FirstOrDefault(e => e.ResourceAndCadreManagementId == Id);
            if (ResourceAndCadreManagement == null)
            {
                throw new NotImplementedException();

            }
            else
            {
              context.ResourceAndCadreManagement.Remove(ResourceAndCadreManagement);
                context.SaveChanges();
            }
        }

        public ResourceAndCadreManagement GetResourceAndCadreManagement(Guid Id)
        {
            var ResourceAndCadreManagement = context.ResourceAndCadreManagement.FirstOrDefault(e => e.ResourceAndCadreManagementId == Id);
            if (ResourceAndCadreManagement == null)
            {
                throw new NotImplementedException();

            }
            else
            {
                return ResourceAndCadreManagement;
            }
        }

        public List<ResourceAndCadreManagement> GetResourceAndCadreManagements()
        {
            return context.ResourceAndCadreManagement.ToList();
        }

        public ResourceAndCadreManagement UpdateResourceAndCadreManagement(Guid Id, ResourceAndCadreManagement resourceAndCadreManagement)
        {
            if (Id != resourceAndCadreManagement.ResourceAndCadreManagementId)
            {
                throw new NotImplementedException();

            }
            else
            {
                context.Entry(resourceAndCadreManagement).State = EntityState.Modified;
                context.SaveChanges();
                return resourceAndCadreManagement;
            }
        }
    }
    }

