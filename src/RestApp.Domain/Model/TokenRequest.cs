using System.ComponentModel.DataAnnotations;

namespace RestApp.Domain.Model
{
    public class TokenRequest
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
        public bool RememberMe { get; set; }
    }
}
