using System.ComponentModel.DataAnnotations;

namespace Model.DTOs;
public class ApplicationUserRegisterDto
{
    [Required]
    public string? Email { get; set; }
    [Required]
    public string? Password { get; set; }
}

public class ApplicationUserLoginDto
{
    [Required]
    public string? Email { get; set; }
    [Required]
    public string? Password { get; set; }
}