using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace Roblocks.Database.services.AuthServices;

public interface IAuthService
{
    string CreateToken(string username, string role = "User");
    bool ValidateCredentials(string username, string password);
}

public class AuthServices : IAuthService
{
    private DataContext _context;
    private readonly IConfiguration _config;

    public AuthServices(IConfiguration config, DataContext context)
    {
        _context = context;
        _config = config;
    }

    public string CreateToken(string username, string role = "User")
    {
        var claims = new[]
        {
            new Claim(ClaimTypes.Name, username),
            new Claim(ClaimTypes.Role, role)
        };
        
        
        var key = new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes(_config["JWT_SECRET"]!)
        );

        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            expires: DateTime.UtcNow.AddHours(8),
            claims: claims,
            signingCredentials: creds
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }

    public bool ValidateCredentials(string username, string password)
    {
        string hashedPassword = BCrypt.Net.BCrypt.HashPassword(password);
        var user = _context.Users
            .FirstOrDefault(u => u.Username == username);

        if (user == null) return false;
        
        return BCrypt.Net.BCrypt.Verify(password, user.HashedPassword);
    }
}