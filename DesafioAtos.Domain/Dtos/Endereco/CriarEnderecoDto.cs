﻿namespace DesafioAtos.Domain.Dtos
{
    public class CriarEnderecoDto
    {

        public string Numero { get; set; }
        public string Complemento { get; set; }
        public string Rua { get; set; }
        public string Cep { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string Bairro { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
