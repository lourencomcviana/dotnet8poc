namespace myapp.@interface.api.request;

public record Person(string FirstName, string LastName, string Cpf, int Age);
public record PersonResponse(string Name, string Cpf, int Age);
public record PersonQuery(string Name, string Cpf);