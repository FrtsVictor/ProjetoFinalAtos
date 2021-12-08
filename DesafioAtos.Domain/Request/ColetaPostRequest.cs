using DesafioAtos.Domain.Entities;

namespace DesafioAtos.Domain.Request
{
    public class ColetaPostRequest
    {
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public List<ItemDeColeta> ItensDeColeta { get; set; }
        public EmpresaColetora EmpresaColetora { get; set; }

        public ColetaPostRequest()
        {
            this.ItensDeColeta = new List<ItemDeColeta>();
        }
    }


}
