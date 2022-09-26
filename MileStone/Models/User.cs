using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations;

namespace MileStone.Models
{
    public class User: IdentityUser
    {
        [Required, MaxLength(50)]
        public string FirstName { get; set; }

        [Required, MaxLength(50)]
        public string LastName { get; set; }

        public DateTime IqamaExpiryDate { get; set; }

        public string PassportNumber { get; set; }

        public DateTime PassportExpiryDate { get; set; }

        public DateTime JoiningDate { get; set; }

        public DateTime ContractRenewalDate { get; set; }

        public string Position { get; set; }

        public string Skills { get; set; }

        public string Status { get; set; }

    }
}
