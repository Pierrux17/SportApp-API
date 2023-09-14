using System.ComponentModel.DataAnnotations;

namespace SportAPI.Models
{
    public class LoginForm
    {
        [Required]
        public string Login { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
