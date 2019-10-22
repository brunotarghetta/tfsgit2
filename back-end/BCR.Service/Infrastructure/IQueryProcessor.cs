using BCR.Business.Domain.Base;
using BCR.Business.Queries;
using System;
using System.Collections.Generic;
using System.Text;

namespace BCR.Service.Infrastructure
{
    public interface IQueryProcessor
    {
        //TResult Process<TResult>(IQuery<TResult> query);

        TResult Process<TQuery, TResult>(TQuery query) where TQuery : IQuery<TResult> where TResult : DataView;
    }
}
