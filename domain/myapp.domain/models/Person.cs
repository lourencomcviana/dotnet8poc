using System.ComponentModel.DataAnnotations;

namespace myapp.domain.models;

public record Person(
    [Required]string Name, 
    [Required]string Surname, 
    [Required][RegularExpression(@"^\d{3}\.\d{3}\.\d{3}-\d{2}$")]string Cpf,
    [Required]int Age
) {
    public string FullName => GetFullName();
    private string GetFullName() => $"{Name} {Surname}";
}