using DesafioAtos.Domain.Entidades;
using System.ComponentModel.DataAnnotations;

namespace DesafioAtos.Domain.Dtos
{
    public class CriarEmpresaColetoraDto
    {
        [Required(ErrorMessage = "Propriedade {0} é obrigatória.")]
        [StringLength(maximumLength: 200, MinimumLength = 4, ErrorMessage = "A propriedade {0}  deve conter entre {1} e {2} caracteres")]
        public string Nome { get; set; } = null!;

        [Required(ErrorMessage = "Propriedade {0} é obrigatória.")]
        [StringLength(maximumLength: 18, MinimumLength = 14, ErrorMessage = "A propriedade {0}  deve conter entre {1} e {2} caracteres")]
        public string Cnpj { get; set; } = null!;

        [Required(ErrorMessage = "Informe o seu email")]
        [RegularExpression(".+\\@.+\\..+", ErrorMessage = "Informe um email válido...")]
        public string Email { get; set; } = null!;


        [Required]
        [DataType(DataType.Password)]
        [StringLength(200, MinimumLength = 5)]
        public string Senha { get; set; } = null!;

        [Required]
        [Phone]
        [StringLength(maximumLength: 14, MinimumLength = 9, ErrorMessage = "A propriedade {0}  deve conter entre {1} e {2} caracteres")]          
        public string Telefone { get; set; } = null!;
        
        
        
        public List<CriarEnderecoDto> Enderecos { get; set; }
        public List<int> Categorias { get; set; }

       
        
        
        public CriarEmpresaColetoraDto()
        {
            this.Enderecos = new List<CriarEnderecoDto>();
            Categorias = new List<int>() { };
        }
    }
}