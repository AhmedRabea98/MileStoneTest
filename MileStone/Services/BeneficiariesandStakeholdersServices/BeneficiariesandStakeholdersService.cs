using Microsoft.EntityFrameworkCore;
using MileStone.Context;
using MileStone.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MileStone.Services.BeneficiariesandStakeholdersServices
{
    public class BeneficiariesandStakeholdersService : IBeneficiariesandStakeholdersService
    {
        private readonly DBContext context;
        public BeneficiariesandStakeholdersService(DBContext context)
        {
            this.context = context;
        }
        public BeneficiariesandStakeholders AddBeneficiariesandStakeholders(BeneficiariesandStakeholders beneficiariesandStakeholders)
        {
            if(beneficiariesandStakeholders == null)
            {
                throw new NotImplementedException();

            }
            else
            {
                
                context.BeneficiariesandStakeholders.Add(beneficiariesandStakeholders);
                context.SaveChanges();
                return beneficiariesandStakeholders;
            }
        }

        public void DeleteBeneficiariesandStakeholders(Guid Id)
        {
            var BAS = context.BeneficiariesandStakeholders.FirstOrDefault(e => e.BeneficiariesandStakeholdersId == Id);
            if(BAS == null)
            {
                throw new NotImplementedException();

            }
            context.BeneficiariesandStakeholders.Remove(BAS);
            context.SaveChanges();
        }

        public List<BeneficiariesandStakeholders> GetBeneficiariesandStakeholders()
        {
            return context.BeneficiariesandStakeholders.ToList();
        }

        public BeneficiariesandStakeholders GetBeneficiariesandStakeholder(Guid Id)
        {
            var BAS = context.BeneficiariesandStakeholders.FirstOrDefault(e => e.BeneficiariesandStakeholdersId == Id);
            if (BAS == null)
            {
                throw new NotImplementedException();

            }
            else
            {
                return BAS;
            }
        }

        public BeneficiariesandStakeholders UpdateBeneficiariesandStakeholders(Guid Id, BeneficiariesandStakeholders beneficiariesandStakeholders)
        {
            if (Id != beneficiariesandStakeholders.BeneficiariesandStakeholdersId)
            {
                throw new NotImplementedException();

            }
            else
            {
                context.Entry(beneficiariesandStakeholders).State = EntityState.Modified;
                context.SaveChanges();
                return beneficiariesandStakeholders;
            }
        }
    }
}
