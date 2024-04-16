using System.Linq.Expressions;

namespace Herfitk.Core.Specifications
{
    public class Specification<T> : ISpecification<T> where T : class
    {
        public Expression<Func<T, bool>>? Criteria { get; set; } = null;
        public List<Expression<Func<T, object>>> Includes { get; set; } = new List<Expression<Func<T, object>>>();

        public Specification()
        { }

        public Specification(Expression<Func<T, bool>> expression)
            => Criteria = expression;
    }
}