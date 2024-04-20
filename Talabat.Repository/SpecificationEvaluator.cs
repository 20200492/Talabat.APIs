using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talabat.Core.Entities;
using Talabat.Core.Specification;

namespace Talabat.Repository
{
    internal static class SpecificationEvaluator<TEntity> where TEntity : BaseEntity 
    {
        public static IQueryable<TEntity> GetQuery(IQueryable<TEntity> InputQuery, ISpecification<TEntity> Spec)
        {
            var query = InputQuery; // query = _dbContext.Set<Products>

            if(Spec.Crateria is not null) // Crateria is null here
                query = query.Where(Spec.Crateria);
            // query = _dbContext.Set<Products>

            //Includes Expressions
            // 1 .P => P.Brand
            // 2 .P => P.Category

            query = Spec.Includes.Aggregate(query, (currentQuery, includeExpression) => currentQuery.Include(includeExpression));
            // query = _dbContext.Set<Products>.Include(P => P.Brand)
            // query = _dbContext.Set<Products>.Include(P => P.Brand).Include(P => P.Category)

            return query;
        }
    }
}
