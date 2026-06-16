using AutoMapper;
using MediatR;
using Tekus.Application.DTOs.Service;
using Tekus.Application.Interfaces.Persistence;

namespace Tekus.Application.Features.Services.Queries.GetServices;

public class GetServicesQueryHandler
    : IRequestHandler<
        GetServicesQuery,
        IEnumerable<ServiceResponseDto>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetServicesQueryHandler(
        IUnitOfWork unitOfWork,
        IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<IEnumerable<ServiceResponseDto>> Handle(
        GetServicesQuery request,
        CancellationToken cancellationToken)
    {
        var services =
            await _unitOfWork.Services.GetAllAsync();

        return _mapper.Map<
            IEnumerable<ServiceResponseDto>>(services);
    }
}