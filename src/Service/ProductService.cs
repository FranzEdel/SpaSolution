using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Model;
using Model.DTOs;
using Persistence.Database;
using Service.Commons;
using Service.Extensions;

namespace Service;

public interface IProductService
{
    Task<DataCollection<ProductDto>> GetAll(int page, int take);
    Task<ProductDto> Create(ProductCreateDto model);
    Task<ProductDto> GetById(int id);
    Task Update(int id, ProductUpdateDto model);
    Task Remove(int id);
}
public class ProductService : IProductService
{
    private readonly ApplicationDbContext _context;
    private readonly IMapper _mapper;
    public ProductService(ApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<DataCollection<ProductDto>> GetAll(int page, int take)
    {
        return _mapper.Map<DataCollection<ProductDto>>(
            await _context.Product.OrderByDescending(x => x.ProductID)
                    .AsQueryable()
                    .PagedAsync(page, take)
        );
    }
    public async Task<ProductDto> GetById(int id)
    {
        var result = await _context.Product.SingleAsync(c => c.ProductID == id);
        return _mapper.Map<ProductDto>(result);
    }

    public async Task<ProductDto> Create(ProductCreateDto model)
    {
        var entry = new Product
        {
            Name = model.Name,
            Description = model.Description,
            Price = model.Price
        };

        await _context.AddAsync(entry);
        await _context.SaveChangesAsync();

        return _mapper.Map<ProductDto>(entry);
    }

    public async Task Update(int id, ProductUpdateDto model)
    {
        var entry = await _context.Product.SingleAsync(c => c.ProductID == id);

        entry.Name = model.Name;
        entry.Description = model.Description;
        entry.Price = model.Price;

        await _context.SaveChangesAsync();
    }

    public async Task Remove(int id)
    {
        _context.Remove(
            new Product { ProductID = id }
        );

        await _context.SaveChangesAsync();
    }

}
