using AutoMapper;
using Model;
using Model.DTOs;

namespace Core.Api.Config;

public class AutoMapperConfig : Profile
{
    public AutoMapperConfig()
    {
        CreateMap<Client, ClientDto>();
        CreateMap<Product, ProductDto>();
    }
}
