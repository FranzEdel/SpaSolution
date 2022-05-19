using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Model.DTOs;
using Model.Identity;

namespace Core.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class IdentityController : ControllerBase
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly SignInManager<ApplicationUser> _signInManager;
    private readonly IConfiguration _configuration;
    public IdentityController(
        UserManager<ApplicationUser> userManager,
        SignInManager<ApplicationUser> signInManager,
        IConfiguration configuration
    )
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _configuration = configuration;
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
            return Ok(
                GenerateToken(user)
            );
        }
        else
        {
            return BadRequest("acceso no valido al Sistema.");
        }

    }

    private string GenerateToken(ApplicationUser user)
    {
        var secretKey = _configuration.GetValue<string>("SecretKey");
        var key = Encoding.ASCII.GetBytes(secretKey);

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new Claim[]{
                new Claim(ClaimTypes.NameIdentifier, user.Id),
                new Claim(ClaimTypes.Email, user.Email)
                //new Claim(ClaimTypes.Name, user.FirstName),
                //new Claim(ClaimTypes.Surname, user.LastName),
            }),
            Expires = DateTime.UtcNow.AddDays(1),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        };

        var tokenHandler = new JwtSecurityTokenHandler();
        var createdToken = tokenHandler.CreateToken(tokenDescriptor);

        return tokenHandler.WriteToken(createdToken);
    }
}
