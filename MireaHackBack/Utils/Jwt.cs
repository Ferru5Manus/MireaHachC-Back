using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace MireaHackBack.Utils;

public class Jwt
{
    private readonly string _issuer;
    private readonly string _audience;
    private readonly string _secret;

    public Jwt()
    {
        _issuer = Environment.GetEnvironmentVariable("JWT_ISSUER") ?? "MireaHackBack";
        _audience = Environment.GetEnvironmentVariable("JWT_AUDIENCE") ?? "MireaHackBack";
        _secret = Environment.GetEnvironmentVariable("JWT_SECRET") ?? "TopSecretKeyForTheProtectionOfChocolateCookiesAndOtherSweetThings";
    }

    public string GrantToken(List<Claim> claims, DateTime expirationDate)
    {
        var jwt = new JwtSecurityToken(
            issuer: _issuer,
            audience: _audience,
            claims: claims,
            expires: expirationDate,
            signingCredentials: new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_secret)), SecurityAlgorithms.HmacSha256));
        var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);
        return encodedJwt;
    }
}