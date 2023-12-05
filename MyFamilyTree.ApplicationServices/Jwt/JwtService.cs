using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using MyFamilyTree.ApplicationServices.Helpers;
using MyFamilyTree.ApplicationServices.Jwt;
using MyFamilyTree.Domain.Entities; 

public class JwtService : IJwtService
{
    private readonly JwtSettings settings;


    public JwtService(IOptions<JwtSettings> settings)
    {
        this.settings = settings.Value;
    }

    public IOptions<JwtSettings> Settings { get; }

    public string GenerateJwtToken(User user)
    {
        var claims = new List<Claim>
      {
          new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
          new Claim(ClaimTypes.Name, user.Username),
          new Claim(ClaimTypes.Role, user.Role.ToString())
      };

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(settings.SecretKey));

        var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var expires = DateTime.Now.AddMinutes(settings.AccessTokenExpirationMinutes);

        var token = new JwtSecurityToken(settings.Issuer, settings.Audience, claims, expires: expires, signingCredentials: credentials);

        var tokenHandler = new JwtSecurityTokenHandler();
        return tokenHandler.WriteToken(token);
    }
}

