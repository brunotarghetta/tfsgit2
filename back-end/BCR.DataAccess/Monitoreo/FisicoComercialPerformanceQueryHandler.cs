using BCR.Business.Domain.Queries;
using BCR.Crosscutting.Exceptions;
using BCR.DataAccess.Base;

namespace BCR.DataAccess
{
    public class FisicoComercialPerformanceQueryHandler : DataAccessor, IQueryHandler<FisicoComercialPerformanceQuery, IndicadorPerformancePendienteEnProcesoResultadoOkDataView>
    {
        public FisicoComercialPerformanceQueryHandler(BcrContext dbContext) 
            : base(dbContext)
        {
        }

        public IndicadorPerformancePendienteEnProcesoResultadoOkDataView Handle(FisicoComercialPerformanceQuery query)
        {
            Argument.ThrowIfNull(() => query);

            return new IndicadorPerformancePendienteEnProcesoResultadoOkDataView();
        }
    }
}
