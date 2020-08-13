using BCR.Business.Domain.Queries;
using BCR.Crosscutting.Exceptions;
using BCR.DataAccess.Base;

namespace BCR.DataAccess
{
    public class LacradoQueryHandler : DataAccessor, IQueryHandler<LacradoQuery, IndicadorPerformanceDataView>
    {
        public LacradoQueryHandler(BcrContext dbContext) 
            : base(dbContext)
        {
        }

        public IndicadorPerformanceDataView Handle(LacradoQuery query)
        {
            Argument.ThrowIfNull(() => query);

            return new IndicadorPerformanceDataView();
        }
    }
}
