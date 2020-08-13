using BCR.Business.Domain.Queries;
using BCR.Crosscutting.Exceptions;
using BCR.Service.Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace BCR.Web.Api.Controllers
{
    [Route("api/monitoreo-lab-quimico")]
    public class MonitoreoLabQuimicoController : BaseController
    {

        private readonly IQueryProcessor queryProcessor;

        public MonitoreoLabQuimicoController(IQueryProcessor queryProcessor)
        {
            Argument.ThrowIfNull(() => queryProcessor);

            this.queryProcessor = queryProcessor;
        }

        public IActionResult Get()
        {
            var result = this.queryProcessor.Process<QuimicoPerformanceQuery, IndicadorPerformancePendienteEnProcesoResultadoOkDataView>(new QuimicoPerformanceQuery());

            return this.Ok(result);
        }
    }
}
