using BCR.Business.Domain.Queries;
using BCR.Crosscutting.Exceptions;
using BCR.Service.Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace BCR.Web.Api.Controllers
{
    [Route("api/monitoreo-lab-lacrado")]
    public class MonitoreoLabLacradoController : BaseController
    {

        private readonly IQueryProcessor queryProcessor;

        public MonitoreoLabLacradoController(IQueryProcessor queryProcessor)
        {
            Argument.ThrowIfNull(() => queryProcessor);

            this.queryProcessor = queryProcessor;
        }

        public IActionResult Get()
        {
            var result = this.queryProcessor.Process<LacradoQuery, IndicadorPerformanceDataView>(new LacradoQuery());

            return this.Ok(result);
        }
    }
}
