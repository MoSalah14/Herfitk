using System.Linq.Expressions;

namespace Herfitk.Core
{
    public interface ISpecification<T> where T : class
    {
        // make this for where if null it get all
        public Expression<Func<T, bool>>? Criteria { get; set; }

        public List<Expression<Func<T, object>>> Includes { get; set; }
        public int Skip { get; set; }
        public int Take { get; set; }

        public bool IspaginationEnable { get; set; }
    }
}