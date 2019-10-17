using System;

namespace BCR.Business.Queries
{
    public abstract class DataView<TId>
    {
        public TId Id { get; set; }
    }

    public class DataView : DataView<Int64>
    {

    }
}
