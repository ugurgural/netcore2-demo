using System.ComponentModel.DataAnnotations;

namespace NetCore2Demo.Entities.Dto
{
    public class RegisterModel
    {
        [Required] public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "PASSWORD_MIN_LENGTH", MinimumLength = 6)]
        public string Password { get; set; }
    }
}