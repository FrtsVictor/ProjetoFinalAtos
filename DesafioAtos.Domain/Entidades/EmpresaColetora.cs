using DesafioAtos.Domain.Entidades;

namespace DesafioAtos.Domain.Entidades
{
    public class EmpresaColetora : EntidadeBase
    {
        public string Name { get; set; }
        public string Cnpj { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }

        public List<Endereco> Endereco { get; set; }

        //criar lista Enum
        public List<Categoria> Categoria { get; set; }
    }
}