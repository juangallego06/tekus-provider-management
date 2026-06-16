using FluentValidation;
using Tekus.Application.DTOs.Provider;

namespace Tekus.Application.Validators;

public class CreateProviderDtoValidator
    : AbstractValidator<CreateProviderDto>
{
    public CreateProviderDtoValidator()
    {
        RuleFor(x => x.Nit)
            .NotEmpty()
            .MaximumLength(20);

        RuleFor(x => x.Name)
            .NotEmpty()
            .MaximumLength(200);

        RuleFor(x => x.Email)
            .NotEmpty()
            .EmailAddress();

        RuleFor(x => x.Website)
            .MaximumLength(250);
    }
}