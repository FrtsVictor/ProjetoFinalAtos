namespace DesafioAtos.Domain.Entidades
{
    public partial class UsuarioEmpresaCategoria : EntidadeBase
    {
        public int? IdEmpresaColetora { get; set; }
        public int? IdUsuario { get; set; }
        public int? IdCategoria { get; set; }

        public virtual Categoria? IdCategoriaNavigation { get; set; }
        public virtual EmpresaColetora? IdEmpresaColetoraNavigation { get; set; }
        public virtual Usuario? IdUsuarioNavigation { get; set; }
    }
}