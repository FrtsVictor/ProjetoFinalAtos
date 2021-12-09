using DesafioAtos.Domain.Entidades;

namespace DesafioAtos.Domain.Entidades
{
    public class Endereco : EntidadeBase
    {
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public string Rua { get; set; }
        public string Cep { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string Bairro { get; set; }
    }
    
}
