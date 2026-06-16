using AutoMapper;
using MediatR;
using Tekus.Application.DTOs.Provider;
using Tekus.Application.Interfaces.Persistence;
using Tekus.Domain.Entities;

namespace Tekus.Application.Features.Providers.Commands.CreateProvider;

public class CreateProviderCommandHandler
    : IRequestHandler<CreateProviderCommand, ProviderResponseDto>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CreateProviderCommandHandler(
        IUnitOfWork unitOfWork,
        IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<ProviderResponseDto> Handle(
        CreateProviderCommand request,
        CancellationToken cancellationToken)
    {
        var exists = await _unitOfWork.Providers
            .ExistsByEmailAsync(request.Email);

        if (exists)
            throw new Exception("Email already exists.");

        var provider = _mapper.Map<Provider>(request);

        await _unitOfWork.Providers.AddAsync(provider);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return _mapper.Map<ProviderResponseDto>(provider);
    }
}