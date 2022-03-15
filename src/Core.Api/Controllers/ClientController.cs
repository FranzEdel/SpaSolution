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

    [HttpPost]
    public async Task<ActionResult> Create(ClientCreateDto model)
    {
        await _clientService.Create(model);
        return Ok();
    }

}
