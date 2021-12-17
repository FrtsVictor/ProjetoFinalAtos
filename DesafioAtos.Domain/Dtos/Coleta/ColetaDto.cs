using System.ComponentModel.DataAnnotations;

namespace DesafioAtos.Domain.Dtos
{
    public class ColetaDto
    {
        public long Id { get; set; }


        [Required(ErrorMessage = "Propriedade {0} é obrigatória.")]
        [StringLength(maximumLength: 200, MinimumLength = 4, ErrorMessage = "A propriedade {0}  deve conter entre {1} e {2} caracteres")]
        public string? Nome { get; set; }


        [Required(ErrorMessage = "Propriedade {0} é obrigatória.")]
        [StringLength(maximumLength: 100, MinimumLength = 3, ErrorMessage = "A propriedade {0}  deve conter entre {1} e {2} caracteres")]
        public string? ItemDeColeta { get; set; }

        [StringLength(maximumLength: 100, ErrorMessage = "O número de caracteres excedeu o limite")]
        public string? Observacao { get; set; }

        public bool Status { get; set; }

        public string? EmpresaColetaId { get; set; }

        public string? Categoria { get; set; }
    }
}