﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ReportAPI.DataAccess
{
    public interface IReportDataAccess<T> where T : class
    {
        T GetById(int id);
        T GetByGuidId(Guid id);
        IEnumerable<T> GetAll();
        IEnumerable<T> Find(Expression<Func<T, bool>> expression);
        bool Add(T entity);
        bool AddRange(IEnumerable<T> entities);
        bool Update(T entity);
        bool Remove(T entity);
        bool RemoveRange(IEnumerable<T> entities);
        bool SaveChanges();

    }
}
