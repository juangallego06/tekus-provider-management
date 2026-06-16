using FluentValidation;

namespace Tekus.Application.Features.Providers.Commands.CreateProvider;

public class CreateProviderCommandValidator
    : AbstractValidator<CreateProviderCommand>
{
    public CreateProviderCommandValidator()
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