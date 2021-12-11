namespace DesafioAtos.Domain.Entidades
{
    public partial class EmpresaColeta : EntidadeBase
    {
        public EmpresaColeta()
        {
            Enderecos = new HashSet<Endereco>();
            UsuarioEmpresaCategoria = new HashSet<UsuarioEmpresaCategoria>();
        }
       
        public string Nome { get; set; } = null!;
        public string Cnpj { get; set; } = null!;
        public string Telefone { get; set; } = null!;
        public string Email { get; set; } = null!;

        public virtual ICollection<Endereco> Enderecos { get; set; }
        public virtual ICollection<UsuarioEmpresaCategoria> UsuarioEmpresaCategoria { get; set; }
    }
}
