using BCR.Business.Domain.Queries;
using BCR.Crosscutting.Exceptions;
using BCR.DataAccess.Base;

namespace BCR.DataAccess
{
    public class IngresoAutomaticoQueryHandler : DataAccessor, IQueryHandler<IngresoAutomaticoQuery, IndicadorPerformanceDataView>
    {
        public IngresoAutomaticoQueryHandler(BcrContext dbContext)
            : base(dbContext)
        {
        }

        public IndicadorPerformanceDataView Handle(IngresoAutomaticoQuery query)
        {
            Argument.ThrowIfNull(() => query);

            return new IndicadorPerformanceDataView();
        }
    }
}
