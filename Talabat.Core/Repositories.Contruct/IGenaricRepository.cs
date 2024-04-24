﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talabat.Core.Entities;
using Talabat.Core.Specification;

namespace Talabat.Core.Repositories.Contruct
{
    public interface IGenaricRepository<T> where T : BaseEntity
    {
        Task<T> GetAsync(int id);
        Task<IReadOnlyList<T>> GetAllAsync();
        Task<IReadOnlyList<T>> GetAllWithSpecAsync(ISpecification<T> Spec);
        Task<T?> GetWithSpecAsync(int id, ISpecification<T> Spec);
        Task<int> GetCountWithSpecAsync(ISpecification<T> Spec );
    }
}
