using System;
using System.ComponentModel.DataAnnotations;

namespace MileStone.DTO
{
    public class RegisterDTO
    {
        [Required, MaxLength(50)]
        public string FirstName { get; set; }

        [Required, MaxLength(50)]
        public string LastName { get; set; }

        [Required]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Email Required")]
        public string Email { get; set; }
        [Required(ErrorMessage ="Password Required")]
        public string Password { get; set; }
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
