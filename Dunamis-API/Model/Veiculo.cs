using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dunamis_API.Model
{
    public class Veiculo
    {

        [Key]
        public int Id { get; set; }

        [StringLength(7, ErrorMessage = "inserir no máximo 7 caracteres")]
        public string? Placa { get; set; }

        [StringLength(200, ErrorMessage = "inserir no máximo 200 caracteres")]
        public string? Modelo { get; set; }

        [StringLength(25, ErrorMessage = "inserir no máximo 25 caracteres")]

        [ForeignKey("Motorista")]
        public int MotoristaId { get; set; }
        public Motorista? Motorista { get; set; }

    }
}
