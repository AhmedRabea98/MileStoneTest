using MileStone.Models;
using System;
using System.Collections.Generic;

namespace MileStone.Services.BeneficiariesandStakeholdersServices
{
    public interface IBeneficiariesandStakeholdersService
    {
        public List<BeneficiariesandStakeholders> GetBeneficiariesandStakeholders();
        public BeneficiariesandStakeholders GetBeneficiariesandStakeholder(Guid Id);
        public BeneficiariesandStakeholders AddBeneficiariesandStakeholders(BeneficiariesandStakeholders beneficiariesandStakeholders);
        public BeneficiariesandStakeholders UpdateBeneficiariesandStakeholders(Guid Id, BeneficiariesandStakeholders beneficiariesandStakeholders);
        public void DeleteBeneficiariesandStakeholders(Guid Id);
    }
}
