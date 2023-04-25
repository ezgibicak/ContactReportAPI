using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReportAPI.DataAccess
{
    public class ReportDataAccess<T> : IReportDataAccess<T> where T : class
    {
        private readonly ReportContext context;
        public ReportDataAccess(ReportContext context)
        {
            this.context = context;
        }
        public bool Add(T entity)
        {
            context.Set<T>().AddAsync(entity);
            return IsSaved();
        }
        public bool AddRange(IEnumerable<T> entities)
        {
            context.Set<T>().AddRangeAsync(entities);
            return IsSaved();
        }
        public bool Update(T entity)
        {
            context.Set<T>().Attach(entity);
            return IsSaved();
        }
        public IEnumerable<T> Find(System.Linq.Expressions.Expression<Func<T, bool>> expression)
        {
            return context.Set<T>().Where(expression);
        }
        public IEnumerable<T> GetAll()
        {
            return context.Set<T>();
        }
        public T GetById(int id)
        {
            return context.Set<T>().Find(id);
        }
        public bool Remove(T entity)
        {
            context.Set<T>().Remove(entity);
            return IsSaved();
        }
        public bool RemoveRange(IEnumerable<T> entities)
        {
            context.Set<T>().RemoveRange(entities);
            return IsSaved();
        }
        public bool SaveChanges()
        {
            try
            {
                context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        private bool IsSaved()
        {
            return SaveChanges();
        }

    }
}
