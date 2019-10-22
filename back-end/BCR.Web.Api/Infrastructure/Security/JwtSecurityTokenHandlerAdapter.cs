using BCR.Business.Domain.Queries.Seguridad;
using BCR.Crosscutting.Exceptions;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace BCR.Web.Api.Infrastructure.Security
{
    public class JwtSecurityTokenHandlerAdapter : IJwtSecurityTokenHandlerAdapter
    {
        private readonly IJwtConfig jwtConfig;

        private readonly IJwtSecurityTokenHandlerFactory jwtSecurityTokenHandlerFactory;

        public JwtSecurityTokenHandlerAdapter(IJwtConfig jwtConfig, IJwtSecurityTokenHandlerFactory jwtSecurityTokenHandlerFactory)
        {
            Argument.ThrowIfNull(() => jwtConfig);
            Argument.ThrowIfNull(() => jwtSecurityTokenHandlerFactory);

            this.jwtConfig = jwtConfig;
            this.jwtSecurityTokenHandlerFactory = jwtSecurityTokenHandlerFactory;
        }
        public JwtSecurityToken CreateToken(AutenticacionUsuarioContraseniaDataView usuario)
        {
            Argument.ThrowIfNull(() => usuario);

            var tokenDescriptor = new SecurityTokenDescriptor()
            {
                Expires = DateTime.UtcNow.AddMinutes(this.jwtConfig.ExpirationMinutes),

                Issuer = this.jwtConfig.Issuer,

                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(this.jwtConfig.SecurityKey), this.jwtConfig.Algorithm),

                Subject = new ClaimsIdentity(new[]
                {
                    // Usuario
                    new Claim(ClaimTypes.NameIdentifier, usuario.Id.ToString(), ClaimValueTypes.Integer64),
                    new Claim(ClaimTypes.Name, usuario.NombreUsuario),
                    new Claim("ssid", usuario.IdSesion.ToString(), ClaimValueTypes.Integer64)
                })
            };

            JwtSecurityTokenHandler tokenHandler = this.jwtSecurityTokenHandlerFactory.Create();
            SecurityToken token = tokenHandler.CreateToken(tokenDescriptor);

            return new JwtSecurityToken()
            {
                Access_token = tokenHandler.WriteToken(token),
                Expires_in = Convert.ToInt32(TimeSpan.FromMinutes(this.jwtConfig.ExpirationMinutes).TotalSeconds),
                Token_type = this.jwtConfig.TokenType
            };
        }

        public ClaimsPrincipal ValidateToken(string token)
        {
            var validationParameters = new TokenValidationParameters()
            {
                IssuerSigningKey = new SymmetricSecurityKey(this.jwtConfig.SecurityKey),

                ValidateAudience = false,

                ValidIssuer = this.jwtConfig.Issuer
            };

            JwtSecurityTokenHandler tokenHandler = this.jwtSecurityTokenHandlerFactory.Create();

            try
            {
                SecurityToken securityToken;
                return tokenHandler.ValidateToken(token, validationParameters, out securityToken);
            }
            catch (Exception ex)
            {
                //Serilog.Log.Logger.ErrorEvent(ex, Event.JwtValidationFailed);

                return null;
            }
        }
    }
}
