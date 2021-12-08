using DesafioAtos.Domain.Dtos;
using DesafioAtos.Domain.Entities;
using DesafioAtos.Domain.Enum;

public class EmpresaColetora : Base
{
    public string Name { get; set; }
    public string Cnpj { get; set; }
    public string Phone { get; set; }
    public string Email { get; set; }
    public List<Endereco> Endereco { get; set; }
    //criar lista Enum
    public List<Categoria> Categoria { get; set; }
}