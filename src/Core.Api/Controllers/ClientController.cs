using Microsoft.AspNetCore.Mvc;
using Model.DTOs;
using Service;

namespace Core.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class ClientController : ControllerBase
{
    private readonly IClientService _clientService;

    public ClientController(IClientService clientService)
    {
        _clientService = clientService;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ClientDto>> GetById(int id)
    {
        return await _clientService.GetById(id);
    }

    [HttpPost]
    public async Task<ActionResult> Create(ClientCreateDto model)
    {
        var result = await _clientService.Create(model);

        return CreatedAtAction(
            "GetById",
            new { id = result.ClientID },
            result
        );
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> Update(int id, ClientUpdateDto model)
    {
        await _clientService.Update(id, model);

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Remove(int id)
    {
        await _clientService.Remove(id);

        return NoContent();
    }

}
