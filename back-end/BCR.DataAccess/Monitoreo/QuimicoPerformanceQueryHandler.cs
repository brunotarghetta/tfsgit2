using BCR.Business.Domain.Queries;
using BCR.Crosscutting.Exceptions;
using BCR.DataAccess.Base;

namespace BCR.DataAccess
{
    public class QuimicoPerformanceQueryHandler : DataAccessor, IQueryHandler<QuimicoPerformanceQuery, IndicadorPerformancePendienteEnProcesoResultadoOkDataView>
    {
        public QuimicoPerformanceQueryHandler(BcrContext dbContext)
            : base(dbContext)
        {
        }

        public IndicadorPerformancePendienteEnProcesoResultadoOkDataView Handle(QuimicoPerformanceQuery query)
        {
            Argument.ThrowIfNull(() => query);

            return new IndicadorPerformancePendienteEnProcesoResultadoOkDataView();
        }
    }
}
