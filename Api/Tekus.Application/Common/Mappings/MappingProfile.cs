using AutoMapper;
using Tekus.Application.DTOs.Provider;
using Tekus.Application.DTOs.Service;
using Tekus.Application.Features.Providers.Commands.CreateProvider;
using Tekus.Application.Features.Services.Commands.CreateService;
using Tekus.Domain.Entities;

namespace Tekus.Application.Common.Mappings;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<CreateProviderCommand, Provider>();

        CreateMap<Provider, ProviderResponseDto>();

        CreateMap<CreateServiceCommand, Service>();

        CreateMap<Service, ServiceResponseDto>()
            .ForCtorParam(
                nameof(ServiceResponseDto.ProviderName),
                opt => opt.MapFrom(src => src.Provider.Name)
            );
    }
}