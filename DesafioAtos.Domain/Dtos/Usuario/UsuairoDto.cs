namespace DesafioAtos.Domain.Dtos;

public class UsuarioDto
{
    public int Id { get; set; }
    public string Login { get; set; } = null!;
    public string Nome { get; set; } = null!;
}