
using DesafioAtos.Domain.Entities;

namespace DesafioAtos.Domain.Dtos
{
    public class EditColetaDto
    {
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public List<ItemDeColeta> ItensDeColeta { get; set; }
        public EmpresaColetora EmpresaColetora { get; set; }
    }
}
