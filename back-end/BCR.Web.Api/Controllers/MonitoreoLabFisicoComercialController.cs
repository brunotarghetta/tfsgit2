using BCR.Business.Domain.Queries;
using BCR.Crosscutting.Exceptions;
using BCR.Service.Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace BCR.Web.Api.Controllers
{

    [Route("api/monitoreo-lab-fisico-comercial")]
    public class MonitoreoLabFisicoComercialController : BaseController
    {

        private readonly IQueryProcessor queryProcessor;

        public MonitoreoLabFisicoComercialController(IQueryProcessor queryProcessor)
        {
            Argument.ThrowIfNull(() => queryProcessor);

            this.queryProcessor = queryProcessor;
        }

        public IActionResult Get()
        {
            var result = this.queryProcessor.Process<FisicoComercialPerformanceQuery, IndicadorPerformancePendienteEnProcesoResultadoOkDataView>(new FisicoComercialPerformanceQuery());

            return this.Ok(result);
        }
    }
}
