using FluentValidation;
using myapp.business.Commands;
using myapp.domain.models;

namespace myapp.business.validations;

public class GeneralCreateUserCommandValidator: AbstractValidator<CreateUserCommand>
{
    public GeneralCreateUserCommandValidator()
    {
        RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required");
        RuleFor(x => x.Surname).NotEmpty().WithMessage("Surname is required");
        RuleFor(x => x.Cpf).NotEmpty().Must(BeAValidCpf).WithMessage("CPF is required");
        RuleFor(x => x.Age).GreaterThan(0).WithMessage("Age is required");
    }
    
    private bool BeAValidCpf(string? cpf)
    {
        if (string.IsNullOrWhiteSpace(cpf))
            return false;

        cpf = cpf.Replace(".", "").Replace("-", "");

        if (cpf.Length != 11 || !long.TryParse(cpf, out _))
            return false;

        var tempCpf = cpf.Substring(0, 9);
        var digitoVerificador1 = CalcularDigitoVerificador(tempCpf);
        var digitoVerificador2 = CalcularDigitoVerificador(tempCpf + digitoVerificador1);

        return cpf.EndsWith(digitoVerificador1.ToString() + digitoVerificador2.ToString());
    }

    private int CalcularDigitoVerificador(string cpf)
    {
        var soma = 0;
        var peso = cpf.Length + 1;

        foreach (var digito in cpf)
        {
            soma += (digito - '0') * peso--;
        }

        var resultado = soma % 11;
        return resultado < 2 ? 0 : 11 - resultado;
    }
    
}