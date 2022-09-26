using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MileStone.Models;
using MileStone.Services.ResourceAndCadreManagementServices;
using System;
using System.Collections.Generic;

namespace MileStone.Controllers.ResourceAndCadreManagementController
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResourceAndCadreManagementController : ControllerBase
    {
        private readonly IResourceAndCadreManagementService resourceAndCadreManagementService;
        public ResourceAndCadreManagementController(IResourceAndCadreManagementService resourceAndCadreManagementService)
        {
            this.resourceAndCadreManagementService = resourceAndCadreManagementService;
        }
        [HttpGet]
        public ActionResult<IEnumerable<ResourceAndCadreManagement>> GetResourceAndCadreManagements()
        {
            return resourceAndCadreManagementService.GetResourceAndCadreManagements();
        }

        // GET: api/BusinessCases/5
        [HttpGet("{id}")]
        public ActionResult<ResourceAndCadreManagement> GetResourceAndCadreManagement(Guid id)
        {
            try
            {
                return resourceAndCadreManagementService.GetResourceAndCadreManagement(id);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        // PUT: api/BusinessCases/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public ResourceAndCadreManagement PutResourceAndCadreManagement(Guid id, ResourceAndCadreManagement resourceAndCadreManagement)
        {
            try
            {
                return resourceAndCadreManagementService.UpdateResourceAndCadreManagement(id, resourceAndCadreManagement);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        // POST: api/BusinessCases
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public ActionResult<ResourceAndCadreManagement> PostResourceAndCadreManagement(ResourceAndCadreManagement resourceAndCadreManagement)
        {
            try
            {
                return resourceAndCadreManagementService.AddResourceAndCadreManagement(resourceAndCadreManagement);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }

        // DELETE: api/BusinessCases/5
        [HttpDelete("{id}")]
        public void DeleteResourceAndCadreManagement(Guid id)
        {
            try
            {
                resourceAndCadreManagementService.DeleteResourceAndCadreManagement(id);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
