using System.ComponentModel.DataAnnotations;

namespace MileStone.DTO
{
    public class LoginDTO
    {
        [Required(ErrorMessage = "Email Required")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Password Required")]
        public string Password { get; set; }
    }
}
