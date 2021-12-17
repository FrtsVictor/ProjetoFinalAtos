<<<<<<< HEAD
﻿namespace DesafioAtos.Domain.Dtos
{
    public class EmpresaColetoraDto
    {
        public int Id { get; set; }
        public string Nome { get; set; } = null!;
=======
﻿using System.ComponentModel.DataAnnotations;

namespace DesafioAtos.Domain.Dtos
{
    public class EmpresaColetoraDto
    {
        [Required(ErrorMessage = "Propriedade {0} é obrigatória.")]
        [StringLength(maximumLength: 200, MinimumLength = 4, ErrorMessage = "A propriedade {0}  deve conter entre {1} e {2} caracteres")]
        public string Nome { get; set; } = null!;

        [Required]
        [Phone]
        [StringLength(maximumLength: 14, MinimumLength = 9, ErrorMessage = "A propriedade {0}  deve conter entre {1} e {2} caracteres")]
>>>>>>> a4c0c85 (datanotation)
        public string Telefone { get; set; } = null!;

        [Required(ErrorMessage = "Informe o seu email")]
        [RegularExpression(".+\\@.+\\..+", ErrorMessage = "Informe um email válido...")]
        public string Email { get; set; } = null!;
<<<<<<< HEAD
=======



>>>>>>> a4c0c85 (datanotation)
        public List<EnderecoDto> Enderecos { get; set; } = new();
    }
}