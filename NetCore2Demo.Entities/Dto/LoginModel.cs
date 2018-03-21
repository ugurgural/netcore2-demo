using System.ComponentModel.DataAnnotations;

namespace NetCore2Demo.Entities.Dto
{
    public class LoginModel
    {
        [Required] public string Email { get; set; }

        [Required] public string Password { get; set; }
    }
}