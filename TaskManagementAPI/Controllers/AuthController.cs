using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using TaskManagementAPI.Models;
using TaskManagementAPI.Repositories;

namespace TaskManagementAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IUserRepository _userRepository;

    public AuthController(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] User loginDetails)
    {
        // 1. Check the database using the injected repository
        var user = await _userRepository.AuthenticateAsync(loginDetails.Username, loginDetails.Password);

        if (user == null)
        {
            return Unauthorized("Invalid username or password.");
        }

        // 2. Generate token if valid
        var claims = new[]
        {
            new Claim(ClaimTypes.Name, user.Username),
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString())
        };

        var key = new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes("ThisIsMySuperSecretKeyForTaskManagementAPI123!")
        );

        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            claims: claims,
            expires: DateTime.Now.AddHours(1),
            signingCredentials: creds
        );

        return Ok(new
        {
            token = new JwtSecurityTokenHandler().WriteToken(token)
        });
    }
    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] User newUser)
    {
        
        await _userRepository.RegisterAsync(newUser);
        return Ok(new { Message = "User registered successfully. You can now log in!" });
    }
}