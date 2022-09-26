using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MileStone.Context;
using MileStone.Models;
using MileStone.Services.BeneficiariesandStakeholdersServices;

namespace MileStone.Controllers.BeneficiariesandStakeholdersController
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class BeneficiariesandStakeholdersController : ControllerBase
    {
      
        private IBeneficiariesandStakeholdersService beneficiariesandStakeholdersService;
        public BeneficiariesandStakeholdersController(IBeneficiariesandStakeholdersService beneficiariesandStakeholdersService)
        {
        
            this.beneficiariesandStakeholdersService = beneficiariesandStakeholdersService;
        }

        // GET: api/BeneficiariesandStakeholders
        [HttpGet]
        public ActionResult<IEnumerable<BeneficiariesandStakeholders>> GetBeneficiariesandStakeholders()
        {
            return  beneficiariesandStakeholdersService.GetBeneficiariesandStakeholders();
        }

        // GET: api/BeneficiariesandStakeholders/5
        [HttpGet("{id}")]
        public  ActionResult<BeneficiariesandStakeholders> GetBeneficiariesandStakeholders(Guid id)
        {


            try
            {
                return beneficiariesandStakeholdersService.GetBeneficiariesandStakeholder(id);

            }catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        // PUT: api/BeneficiariesandStakeholders/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public BeneficiariesandStakeholders PutBeneficiariesandStakeholders(Guid id, BeneficiariesandStakeholders beneficiariesandStakeholders)
        {
            try
            {
                return beneficiariesandStakeholdersService.UpdateBeneficiariesandStakeholders(id, beneficiariesandStakeholders);
            }
            catch (Exception ex)
            {
                throw new Exception (ex.Message);   
            }
        }

        // POST: api/BeneficiariesandStakeholders
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public BeneficiariesandStakeholders PostBeneficiariesandStakeholders(BeneficiariesandStakeholders beneficiariesandStakeholders)
        {
            try
            {
                return beneficiariesandStakeholdersService.AddBeneficiariesandStakeholders(beneficiariesandStakeholders);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        // DELETE: api/BeneficiariesandStakeholders/5
        [HttpDelete("{id}")]
        public void DeleteBeneficiariesandStakeholders(Guid id)
        {
            try
            {
                 beneficiariesandStakeholdersService.DeleteBeneficiariesandStakeholders(id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

       
    }
}
