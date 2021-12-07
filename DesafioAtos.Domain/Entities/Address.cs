namespace DesafioAtos.Domain.Entities;

public class Address : Base
{
    public int Number { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public string Street { get; set; }
}