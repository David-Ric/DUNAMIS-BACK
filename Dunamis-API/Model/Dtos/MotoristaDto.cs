using System.ComponentModel.DataAnnotations;

namespace Dunamis_API.Model.Dtos
{
    public class MotoristaDto
    {
        [Key]
        public int Id { get; set; }
        [StringLength(20, ErrorMessage = "inserir no máximo 20 caracteres")]
        public string? Cpf { get; set; }
        [StringLength(400, ErrorMessage = "inserir no máximo 400 caracteres")]
        public string? Nome { get; set; }
        [StringLength(40, ErrorMessage = "inserir no máximo 40 caracteres")]
        public string? Fone { get; set; }
        [StringLength(300, ErrorMessage = "inserir no máximo 300 caracteres")]
        public string? Email { get; set; }
    }
}
