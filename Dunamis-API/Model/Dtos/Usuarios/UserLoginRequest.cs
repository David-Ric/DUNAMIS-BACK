using System.ComponentModel.DataAnnotations;

namespace Dunamis_API.Model.Dtos.Usuarios
{
    public class UserLoginRequest
    {
        [Required]
        public string Username { get; set; } = string.Empty;

        [Required]
        public string Password { get; set; } = string.Empty;

    }
}
