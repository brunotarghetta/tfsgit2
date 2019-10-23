using BCR.Business.Domain.Queries.Seguridad;
using BCR.Crosscutting.Exceptions;
using BCR.Service.Infrastructure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace BCR.Web.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class PermisosController : ControllerBase
    {
        private readonly IQueryProcessor queryProcessor;

        public PermisosController(IQueryProcessor queryProcessor)
        {
            Argument.ThrowIfNull(() => queryProcessor);

            this.queryProcessor = queryProcessor;
        }

        public ActionResult<string[]> Post(PermisosPorUsuarioQuery query)
        {
            IEnumerable<String> permisos = this.queryProcessor.Process<PermisosPorUsuarioQuery, IEnumerable<String>>(query);

            return this.Ok(permisos);
        }
    }
}