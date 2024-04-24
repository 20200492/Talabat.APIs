using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Talabat.Core.Entities;

namespace Talabat.Core.Specification
{
    public class BaseSpecifications<T> : ISpecification<T> where T : BaseEntity
    {
        public Expression<Func<T, bool>>? Crateria { get; set; } = null;
        public List<Expression<Func<T, object>>> Includes { get; set; } = new List<Expression<Func<T, object>>>();
        public Expression<Func<T,object>> OrderBy { get; set; }
        public Expression<Func<T, object>> OrderByDesc { get; set; }
        public bool IsPaginationEnabeld { get; set; }
        public int Skip { get; set ; }
        public int Take { get; set; }

        public BaseSpecifications()
        {
            //Includes = new List<Expression<Func<T, object>>>();
            // Crateria = null
        }

        public BaseSpecifications(Expression<Func<T, bool>>? crateriaExpression)
        {
            //Includes = new List<Expression<Func<T, object>>>();
            Crateria = crateriaExpression;
        }

        public void ApplyPagination(int skip, int take)
        {
            IsPaginationEnabeld = true;
            Skip = skip;
            Take = take;
        }
    }
}
