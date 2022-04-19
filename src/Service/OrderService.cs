using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Model;
using Model.DTOs;
using Persistence.Database;
using Service.Commons;
using Service.Extensions;

namespace Service;

public interface IOrderService
{
    Task<DataCollection<OrderDto>> GetAll(int page, int take);
    Task<OrderDto> GetById(int id);
    Task<OrderDto> Create(OrderCreateDto model);
}

public class OrderService : IOrderService
{
    private readonly ApplicationDbContext _context;
    private readonly IMapper _mapper;
    private const decimal IvaRate = 0.16m;

    public OrderService(
        ApplicationDbContext context,
        IMapper mapper
    )
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<DataCollection<OrderDto>> GetAll(int page, int take)
    {
        return _mapper.Map<DataCollection<OrderDto>>(
            await _context.Order.OrderByDescending(x => x.OrderID)
                                .Include(x => x.Client)
                                .Include(x => x.Items)
                                    .ThenInclude(x => x.Product)
                                .AsQueryable()
                                .PagedAsync(page, take)
        );
    }

    public async Task<OrderDto> GetById(int id)
    {
        return _mapper.Map<OrderDto>(
            await _context.Order
                .Include(x => x.Client)
                .Include(x => x.Items)
                    .ThenInclude(x => x.Product)
                .SingleAsync(x => x.OrderID == id)
        );
    }

    public async Task<OrderDto> Create(OrderCreateDto model)
    {
        var entry = _mapper.Map<Order>(model);

        // Prepare order detail
        PrepareDetail(entry.Items);

        // Prepare order header
        PrepareHeader(entry);

        await _context.AddAsync(entry);
        await _context.SaveChangesAsync();

        return _mapper.Map<OrderDto>(
            await GetById(entry.OrderID)
        );
    }

    private void PrepareDetail(IEnumerable<OrderDetail> items)
    {
        foreach (var item in items)
        {
            item.Total = item.UnitPrice * item.Quantity;
            item.Iva = item.Total * IvaRate;
            item.SubTotal = item.Total - item.Iva;
        }
    }

    private void PrepareHeader(Order order)
    {
        order.SubTotal = order.Items.Sum(x => x.SubTotal);
        order.Iva = order.Items.Sum(x => x.Iva);
        order.Total = order.Items.Sum(x => x.Total);
    }
}
