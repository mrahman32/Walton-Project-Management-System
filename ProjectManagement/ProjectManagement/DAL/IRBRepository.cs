﻿using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagement.DAL
{
    interface IRBRepository<TEntity> where TEntity : class
    {
        TEntity Get(long id, string includeProperties = "");
        List<TEntity> GetAll(string includeProperties = "");
        List<TEntity> Find(Expression<Func<TEntity, bool>> predicate, string includeProperties = "");

        void Add(TEntity entiry);
        void AddRange(IEnumerable<TEntity> entities);
        void Update(TEntity entityToUpdate);
        void UpdateRange(IEnumerable<TEntity> entitiesToUpdate);
        void Remove(object id);
        void Remove(TEntity entiry);
        void RemoveRange(IEnumerable<TEntity> entities);
    }
}
