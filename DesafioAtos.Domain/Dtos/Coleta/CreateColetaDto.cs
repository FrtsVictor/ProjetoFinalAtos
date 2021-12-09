using DesafioAtos.Domain.Entidades;

namespace DesafioAtos.Domain.Dtos
{
    public class CreateColetaDto
    {
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public List<ItemDeColeta> ItensDeColeta { get; set; }
        public EmpresaColetora EmpresaColetora { get; set; }
        public CreateColetaDto()
        {
            this.ItensDeColeta = new List<ItemDeColeta>();
        }
    }
}
