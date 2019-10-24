using System;

namespace BCR.Business.Domain.Queries
{
    public abstract class DataView<TId>
    {
        public TId Id { get; set; }
    }

    public class DataView : DataView<Int64>
    {

    }
}
