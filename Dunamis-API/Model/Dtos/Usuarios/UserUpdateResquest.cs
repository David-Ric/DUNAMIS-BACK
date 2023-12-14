using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dunamis_API.Model.Dtos.Usuarios
{
    public class UserUpdateResquest
    {
        [Key]
        public int Id { get; set; }
        public string Email { get; set; } = string.Empty;
        public string? Username { get; set; }
        public string? NomeCompleto { get; set; }
        public string? Status { get; set; }
        public string? Funcao { get; set; }
        public string? Telefone { get; set; }

    }
}
