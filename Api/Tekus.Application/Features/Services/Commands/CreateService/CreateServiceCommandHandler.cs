using AutoMapper;
using MediatR;
using Tekus.Application.DTOs.Service;
using Tekus.Application.Interfaces.Persistence;
using Tekus.Application.Interfaces.Services;
using Tekus.Domain.Entities;

namespace Tekus.Application.Features.Services.Commands.CreateService;

public class CreateServiceCommandHandler
    : IRequestHandler<CreateServiceCommand, ServiceResponseDto>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly IEmailService _emailService;

    public CreateServiceCommandHandler(
        IUnitOfWork unitOfWork,
        IMapper mapper,
        IEmailService emailService)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _emailService = emailService;
    }

    public async Task<ServiceResponseDto> Handle(
        CreateServiceCommand request,
        CancellationToken cancellationToken)
    {
        var provider =
            await _unitOfWork.Providers.GetByIdAsync(
                request.ProviderId);

        if (provider is null)
        {
            throw new Exception(
                "Provider not found.");
        }

        var service = new Service
        {
            Name = request.Name,
            HourlyRate = request.HourlyRate,
            ProviderId = request.ProviderId
        };

        await _unitOfWork.Services.AddAsync(service);

        await _unitOfWork.SaveChangesAsync(
            cancellationToken);

        await _emailService.SendServiceCreatedAsync(
            provider.Email,
            provider.Name,
            service.Name);

        return new ServiceResponseDto(
            service.Id,
            service.Name,
            service.HourlyRate,
            provider.Id,
            provider.Name
        );
    }
}