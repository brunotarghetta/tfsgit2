using BCR.Business.Domain.Queries;
using System;
using System.Security.Claims;

namespace BCR.Web.Api.Infrastructure.Security
{
    public interface IJwtSecurityTokenHandlerAdapter
    {
        JwtSecurityToken CreateToken(AutenticacionUsuarioContraseniaDataView usuario);

        ClaimsPrincipal ValidateToken(String token);
    }
}
