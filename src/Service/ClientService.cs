using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Model;
using Model.DTOs;
using Persistence.Database;

namespace Service;

public interface IClientService
{
    Task<ClientDto> Create(ClientCreateDto model);
    Task<ClientDto> GetById(int id);
    Task Update(int id, ClientUpdateDto model);
    Task Remove(int id);
}
public class ClientService : IClientService
{
    private readonly ApplicationDbContext _context;
    private readonly IMapper _mapper;
    public ClientService(ApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public async Task<ClientDto> GetById(int id)
    {
        var result = await _context.Client.SingleAsync(c => c.ClientID == id);
        return _mapper.Map<ClientDto>(result);
    }

    public async Task<ClientDto> Create(ClientCreateDto model)
    {
        var entry = new Client
        {
            Name = model.Name
        };

        await _context.AddAsync(entry);
        await _context.SaveChangesAsync();

        return _mapper.Map<ClientDto>(entry);
    }

    public async Task Update(int id, ClientUpdateDto model)
    {
        var entry = await _context.Client.SingleAsync(c => c.ClientID == id);

        entry.Name = model.Name;

        await _context.SaveChangesAsync();
    }

    public async Task Remove(int id)
    {
        _context.Remove(
            new Client { ClientID = id }
        );

        await _context.SaveChangesAsync();
    }

}
