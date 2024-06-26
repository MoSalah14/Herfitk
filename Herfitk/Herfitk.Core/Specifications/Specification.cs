﻿using System.Linq.Expressions;

namespace Herfitk.Core.Specifications
{
    public class Specification<T> : ISpecification<T> where T : class
    {
        public Expression<Func<T, bool>>? Criteria { get; set; } = null;
        public List<Expression<Func<T, object>>> Includes { get; set; } = new List<Expression<Func<T, object>>>();
        public int Skip { get; set; }
        public int Take { get; set; }
        public bool IspaginationEnable { get; set; }

        public Specification()
        { }

        public Specification(Expression<Func<T, bool>> expression)
            => Criteria = expression;

        public void ApplyPagination(int skip, int take)
        {
            IspaginationEnable = true;
            Skip = skip;
            Take = take;
        }
    }
}