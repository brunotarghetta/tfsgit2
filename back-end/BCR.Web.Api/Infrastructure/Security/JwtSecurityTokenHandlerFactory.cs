using System.IdentityModel.Tokens.Jwt;

namespace BCR.Web.Api.Infrastructure.Security
{
    public class JwtSecurityTokenHandlerFactory : IJwtSecurityTokenHandlerFactory
    {
        public JwtSecurityTokenHandler Create()
        {
            return new JwtSecurityTokenHandler();
        }
    }
}
