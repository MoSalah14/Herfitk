using Herfitk.Core;
using Microsoft.EntityFrameworkCore;

namespace Herfitk.Repository
{
    public static class SpecificationEvaluator<T> where T : class
    {
        public static IQueryable<T> GetQuery(IQueryable<T> context, ISpecification<T> spec)
        {
            var getQuery = context;

            if (spec.Criteria != null)
                getQuery = getQuery.Where(spec.Criteria);

            if (spec.IspaginationEnable)
                getQuery = getQuery.Skip(spec.Skip).Take(spec.Take);

            getQuery = spec.Includes.Aggregate(getQuery, (curQery, includeexpre) => curQery.Include(includeexpre));
            return getQuery;
        }
    }
}