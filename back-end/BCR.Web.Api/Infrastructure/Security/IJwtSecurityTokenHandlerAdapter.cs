using BCR.Business.Domain.Queries.Seguridad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace BCR.Web.Api.Infrastructure.Security
{
    public interface IJwtSecurityTokenHandlerAdapter
    {
        JwtSecurityToken CreateToken(AutenticacionUsuarioContraseniaDataView usuario);

        ClaimsPrincipal ValidateToken(String token);
    }
}
