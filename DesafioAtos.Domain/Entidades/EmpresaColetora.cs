using DesafioAtos.Domain.Enums;

namespace DesafioAtos.Domain.Entidades
{
    public partial class EmpresaColetora : EntidadeBase
    {
        public EmpresaColetora()
        {
            Enderecos = new HashSet<Endereco>();
            UsuarioEmpresaCategoria = new HashSet<UsuarioEmpresaCategoria>();
        }

        public string Senha { get; set; } = null!;
        public string Nome { get; set; } = null!;
        public string Cnpj { get; set; } = null!;
        public string Telefone { get; set; } = null!;
        public string Email { get; set; } = null!;
        public DateTime? DataCriacao { get; set; } = DateTime.Now;
        public ERole Role { get; private set; } = ERole.EmpresaColetora;

        public virtual ICollection<Endereco> Enderecos { get; set; }
        public virtual ICollection<UsuarioEmpresaCategoria> UsuarioEmpresaCategoria { get; set; }
    }
}
