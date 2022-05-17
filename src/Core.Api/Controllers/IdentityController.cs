using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Model.DTOs;
using Model.Identity;

namespace Core.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class IdentityController : ControllerBase
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly SignInManager<ApplicationUser> _signInManager;
    public IdentityController(
        UserManager<ApplicationUser> userManager,
        SignInManager<ApplicationUser> signInManager
    )
    {
        _userManager = userManager;
        _signInManager = signInManager;
    }

    //identity/register
    [HttpPost("register")]
    public async Task<IActionResult> Create(ApplicationUserRegisterDto model)
    {
        var result = await _userManager.CreateAsync(
            new ApplicationUser
            {
                Email = model.Email,
                UserName = model.Email
            }, model.Password
        );

        if (!result.Succeeded)
        {
            throw new Exception("No se pudo registrar el usuario");
        }

        return Ok();
    }

    //identity/login
    [HttpPost("login")]
    public async Task<IActionResult> Login(ApplicationUserLoginDto model)
    {
        var user = await _userManager.FindByEmailAsync(model.Email);
        var check = await _signInManager.CheckPasswordSignInAsync(user, model.Password, false);

        if (check.Succeeded)
        {
            return Ok();
        }
        else
        {
            return BadRequest("acceso no valido al Sistema.");
        }

    }
}
