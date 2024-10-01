using System.ComponentModel.DataAnnotations;

namespace myapp.infra.repository.memory.entities;

public class PersonEntity
{
    [Key] 
    [StringLength(11)]
    public required string Cpf { get; set; }
    [StringLength(100)]
    public required string Name  { get; set; }
    public required int Age  { get; set; }
    
    public string FirstName => Name.Contains(' ') ? Name.Split(' ', 2)[0] : "";
    public string LastName =>  Name.Contains(' ') ? Name.Split(' ', 2)[1] : "";
}
