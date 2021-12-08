namespace DesafioAtos.Domain.Entities
{
    public class Coleta : Base
    {
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public List<ItemDeColeta> ItensDeColeta { get; set; }
        public EmpresaColetora EmpresaColetora { get; set; }
    }
}
