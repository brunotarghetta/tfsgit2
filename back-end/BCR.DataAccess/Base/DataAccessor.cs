using BCR.Crosscutting.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace BCR.DataAccess.Base
{
    public abstract class DataAccessor
    {
        private readonly BcrContext dbContext;

        public DataAccessor(BcrContext dbContext)
        {
            Argument.ThrowIfNull(() => dbContext);

            this.dbContext = dbContext;
        }

        protected BcrContext Session
        {
            get
            {
                if (dbContext == null)
                    throw new InvalidOperationException("NoAmbientSessionFound");

                return this.dbContext;
            }
        }
    }
}
