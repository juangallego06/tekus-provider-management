using FluentValidation;
using Tekus.Application.DTOs.Service;

namespace Tekus.Application.Validators;

public class CreateServiceDtoValidator
    : AbstractValidator<CreateServiceDto>
{
    public CreateServiceDtoValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .MaximumLength(200);

        RuleFor(x => x.HourlyRate)
            .GreaterThan(0);

        RuleFor(x => x.ProviderId)
            .GreaterThan(0);
    }
}