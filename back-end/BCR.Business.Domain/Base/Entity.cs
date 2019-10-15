using System;
using System.Collections.Generic;
using System.Reflection;

namespace BCR.Business.Domain.Base
{
    public abstract class Entity<TId> : ComparableObject
    {
        public virtual TId Id { get; protected set; }

        protected Entity()
        {
        }

        protected Entity(TId id)
        {
            this.Id = id;
        }

        public virtual Boolean IsTransient()
        {
            return this.Id == null || this.Id.Equals(default(TId));
        }

        protected override IEnumerable<PropertyInfo> GetTypeSpecificSignatureProperties()
        {
            return new[] { this.GetType().GetProperty(nameof(this.Id)) };
        }
    }

    public abstract class Entity : Entity<Int64>
    {
        protected Entity()
        {
        }

        protected Entity(Int64 id)
            : base(id)
        {
        }
    }
}
