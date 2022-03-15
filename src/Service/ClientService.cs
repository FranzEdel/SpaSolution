using Model;
using Model.DTOs;
using Persistence.Database;

namespace Service;

public interface IClientService
{
    Task Create(ClientCreateDto model);
}
public class ClientService : IClientService
{
    private readonly ApplicationDbContext _context;
    public ClientService(ApplicationDbContext context)
    {
        _context = context;
    }
    public async Task Create(ClientCreateDto model)
    {
        var entry = new Client
        {
            Name = model.Name
        };

        await _context.AddAsync(entry);
        await _context.SaveChangesAsync();
    }

}
