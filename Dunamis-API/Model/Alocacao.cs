using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dunamis_API.Model
{
    public class Alocacao
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Veiculo")]
        public int VeiculoId { get; set; }
        public Veiculo? Veiculo { get; set; }

        [ForeignKey("Distribuidora")]
        public int DistribuidoraId { get; set; }
        public Distribuidora? Distribuidora { get; set; }

        [StringLength(300, ErrorMessage = "inserir no máximo 300 caracteres")]
        public string Carga { get; set; }
        public int? Peso { get; set; }

        [StringLength(400, ErrorMessage = "inserir no máximo 400 caracteres")]
        public string? Obs { get; set; }
        public DateTime? Entrada { get; set; }
        public bool? Checado { get; set; }
        public DateTime? Saída { get; set; }

    }
}
