using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BCR.Business.Domain.Queries.Seguridad;
using BCR.Crosscutting.Exceptions;
using BCR.Service.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BCR.Web.Api.Controllers
{
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