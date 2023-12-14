using System.ComponentModel.DataAnnotations;

namespace Dunamis_API.Model
{
    public class Distribuidora
    {
        [Key]
        public int Id { get; set; }

        [StringLength(30, ErrorMessage = "inserir no máximo 30 caracteres")]
        public string? Cnpj { get; set; }
        [StringLength(400, ErrorMessage = "inserir no máximo 400 caracteres")]
        public string? Razao_Social { get; set; }
        [StringLength(40, ErrorMessage = "inserir no máximo 40 caracteres")]
        public string? Fone { get; set; }
        [StringLength(300, ErrorMessage = "inserir no máximo 300 caracteres")]
        public string? Email { get; set; }

        [StringLength(400, ErrorMessage = "inserir no máximo 400 caracteres")]
        public string? Logradouro { get; set; }

        [StringLength(200, ErrorMessage = "inserir no máximo 200 caracteres")]
        public string? Municipio { get; set; }

        [StringLength(2, ErrorMessage = "inserir no máximo 2 caracteres")]
        public string? Uf { get; set; }

    }
}
