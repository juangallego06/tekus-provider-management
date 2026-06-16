using AutoMapper;
using MediatR;
using Tekus.Application.DTOs.Provider;
using Tekus.Application.Interfaces.Persistence;

namespace Tekus.Application.Features.Providers.Queries.GetProviders;

public class GetProvidersQueryHandler
    : IRequestHandler<
        GetProvidersQuery,
        IEnumerable<ProviderResponseDto>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetProvidersQueryHandler(
        IUnitOfWork unitOfWork,
        IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<IEnumerable<ProviderResponseDto>> Handle(
        GetProvidersQuery request,
        CancellationToken cancellationToken)
    {
        var providers = await _unitOfWork
            .Providers
            .GetAllAsync();

        return _mapper.Map<IEnumerable<ProviderResponseDto>>(providers);
    }
}