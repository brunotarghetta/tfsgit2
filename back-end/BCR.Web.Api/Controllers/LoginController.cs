using BCR.Business.Domain.Commands.Seguridad;
using BCR.Business.Domain.Queries.Seguridad;
using BCR.Crosscutting.Exceptions;
using BCR.Service.Infrastructure;
using BCR.Web.Api.Infrastructure.Security;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BCR.Web.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IQueryProcessor queryProcessor;

        private readonly IJwtSecurityTokenHandlerAdapter jwtSecurityTokenHandlerAdapter;

        private readonly ICommandProcessor commandProcessor;

        public LoginController(IQueryProcessor queryProcessor, 
                                ICommandProcessor commandProcessor,
                                IJwtSecurityTokenHandlerAdapter jwtSecurityTokenHandlerAdapter)
        {
            Argument.ThrowIfNull(() => queryProcessor);
            Argument.ThrowIfNull(() => commandProcessor);
            Argument.ThrowIfNull(() => jwtSecurityTokenHandlerAdapter);

            this.queryProcessor = queryProcessor;
            this.commandProcessor = commandProcessor;
            this.jwtSecurityTokenHandlerAdapter = jwtSecurityTokenHandlerAdapter;
        }

        [AllowAnonymous]
        public ActionResult<JwtSecurityToken> Post([FromBody] AutenticacionUsuarioContraseniaQuery query)
        {
            Argument.ThrowIfNull(() => query);

            //query.DireccionIP = this.ipAddressResolver.ResolveClientIPAddress(this.Request);

            var usuario = this.queryProcessor.Process<AutenticacionUsuarioContraseniaQuery, AutenticacionUsuarioContraseniaDataView>(query);
            //if (usuario == null)
            //{
            //    Log.Logger.ErrorEvent(Event.LoginFailed, LoginFailedMessageTemplate, query.NombreUsuario, query.IdTerminal);
            //}

            //if (usuario == null ||
            //    !this.EsUsuarioAutenticadoPorLdap(query.NombreUsuario, query.Contrasenia))
            //{
            //    return this.Unauthorized();
            //}

            this.CrearSesion(usuario);

            JwtSecurityToken token = this.CrearJsonWebToken(usuario);

            return this.Ok(token);
        }

        private void CrearSesion(AutenticacionUsuarioContraseniaDataView usuario)
        {
            var command = new CrearSesionCommand()
            {
                IdUsuario = usuario.Id,
                UserAgent = ""
            };

            this.commandProcessor.Process(command);
            usuario.IdSesion = command.IdSesionCreada;
        }

        private JwtSecurityToken CrearJsonWebToken(AutenticacionUsuarioContraseniaDataView usuario)
        {
            JwtSecurityToken token = this.jwtSecurityTokenHandlerAdapter.CreateToken(usuario);

            // const String LoginSuccededMessageTemplate = "Usuario: {NombreUsuario}, Sesión: {SessionId}";

            // Log.Logger.InformationEvent(Event.LoginSucceded, LoginSuccededMessageTemplate, usuario.NombreUsuario, usuario.IdTerminal, usuario.IdSesion);

            return token;
        }
    }
}