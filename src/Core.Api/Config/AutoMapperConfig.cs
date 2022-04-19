using AutoMapper;
using Model;
using Model.DTOs;
using Service.Commons;

namespace Core.Api.Config;

public class AutoMapperConfig : Profile
{
    public AutoMapperConfig()
    {
        CreateMap<Client, ClientDto>();
        CreateMap<DataCollection<Client>, DataCollection<ClientDto>>();

        CreateMap<Product, ProductDto>();
        CreateMap<DataCollection<Product>, DataCollection<ProductDto>>();

        CreateMap<Order, OrderDto>();
        CreateMap<OrderDetail, OrderDetailDto>();
        CreateMap<DataCollection<Order>, DataCollection<OrderDto>>();

        // Order creation
        CreateMap<OrderCreateDto, Order>();
        CreateMap<OrderDetailCreateDto, OrderDetail>();
    }
}
