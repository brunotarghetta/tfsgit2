using BCR.Business.Domain.Queries;
using BCR.Crosscutting.Exceptions;
using BCR.Service.Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace BCR.Web.Api.Controllers
{

    [Route("api/monitoreo-lab-ingreso-automatico")]
    public class MonitoreoLabIngresoAutomaticoController : BaseController
    {

        private readonly IQueryProcessor queryProcessor;

        public MonitoreoLabIngresoAutomaticoController(IQueryProcessor queryProcessor)
        {
            Argument.ThrowIfNull(() => queryProcessor);

            this.queryProcessor = queryProcessor;
        }

        public IActionResult Get()
        {
            var result = this.queryProcessor.Process<IngresoAutomaticoQuery, IndicadorPerformanceDataView>(new IngresoAutomaticoQuery());

            return this.Ok(result);
        }
    }
}
