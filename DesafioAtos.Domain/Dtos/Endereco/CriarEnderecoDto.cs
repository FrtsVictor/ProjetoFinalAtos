using System.ComponentModel.DataAnnotations;

namespace DesafioAtos.Domain.Dtos
{
    public class CriarEnderecoDto
    {
<<<<<<< HEAD
        public string Numero { get; set; } = null!;
        public string Complemento { get; set; } = null!;
        public string Rua { get; set; } = null!;
        public string Cep { get; set; } = null!;
        public string Cidade { get; set; } = null!;
        public string Estado { get; set; } = null!;
=======

        [Required(ErrorMessage = "Propriedade {0} é obrigatória.")]
        [StringLength(maximumLength: 200, MinimumLength = 4, ErrorMessage = "A propriedade {0}  deve conter entre {1} e {2} caracteres")]
        public string Numero { get; set; } = null!;

        [StringLength(maximumLength: 20, ErrorMessage = "O número de caracteres excedeu o limite")]
        public string Complemento { get; set; } = null!;

        [Required(ErrorMessage = "Propriedade {0} é obrigatória.")]
        [StringLength(maximumLength: 100, MinimumLength = 2, ErrorMessage = "A propriedade {0}  deve conter entre {1} e {2} caracteres")]
        public string Rua { get; set; } = null!;

        [Required(ErrorMessage = "Propriedade {0} é obrigatória.")]
        [StringLength(maximumLength: 8, MinimumLength = 8, ErrorMessage = "O Cep deve ter 8 caracteres")]
        public string Cep { get; set; } = null!;

        [Required(ErrorMessage = "Propriedade {0} é obrigatória.")]
        [StringLength(maximumLength: 50, MinimumLength = 2, ErrorMessage = "A propriedade {0}  deve conter entre {1} e {2} caracteres")]
        public string Cidade { get; set; } = null!;

        [Required(ErrorMessage = "Propriedade {0} é obrigatória.")]
        [StringLength(maximumLength: 50, MinimumLength = 2, ErrorMessage = "A propriedade {0}  deve conter entre {1} e {2} caracteres")]
        public string Estado { get; set; } = null!;

        [Required(ErrorMessage = "Propriedade {0} é obrigatória.")]
        [StringLength(maximumLength: 20, MinimumLength = 2, ErrorMessage = "A propriedade {0}  deve conter entre {1} e {2} caracteres")]
>>>>>>> a4c0c85 (datanotation)
        public string Bairro { get; set; } = null!;
    }
}