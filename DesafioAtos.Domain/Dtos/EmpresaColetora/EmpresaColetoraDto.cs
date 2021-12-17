﻿namespace DesafioAtos.Domain.Dtos
{
    public class EmpresaColetoraDto
    {
        public int Id { get; set; }
        public string Nome { get; set; } = null!;
        public string Telefone { get; set; } = null!;
        public string Email { get; set; } = null!;
        public List<EnderecoDto> Enderecos { get; set; } = new();
    }
}