using System.IdentityModel.Tokens.Jwt;

namespace BCR.Web.Api.Infrastructure.Security
{
    public interface IJwtSecurityTokenHandlerFactory
    {
        JwtSecurityTokenHandler Create();
    }
}
