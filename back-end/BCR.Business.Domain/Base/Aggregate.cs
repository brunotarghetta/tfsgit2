using System;
using System.Collections.Generic;
using System.Text;

namespace BCR.Business.Domain.Base
{
    public abstract class Aggregate : Entity
    {
        public Aggregate()
        {

        }

        public Aggregate(Int64 id) : base(id)
        {

        }
    }
}
