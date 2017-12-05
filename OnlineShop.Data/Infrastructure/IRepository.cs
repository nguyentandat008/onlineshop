using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Data.Infrastructure
{
    public interface IRepository<T> where T : class
    {
        // Marks an entity as new
        void Add(T entity);

        // Marks an entity as modified
        void Update(T entity);

        // Marks an entity to be remove
        void Delete(T entity);

        // Delete multi records
        void DeleteMulti(Expression<Func<T, bool>> where);

        // Get an entity by int id
        void GetSingleById(int id);

        // Get an entity by condition
        void GetSingleByCondition(Expression<Func<T, bool>> expression, string[] includes = null);

        // Get all, include child table
        IEnumerable<T> GetAll(string[] includes = null);

        // Get multi records
        IEnumerable<T> GetMulti(Expression<Func<T, bool>> predicate, string[] includes = null);

        // Get multi paging
        IEnumerable<T> GetMultiPaging(Expression<Func<T, bool>> filter, out int total, int index = 0, int size = 50, string[] includes = null);

        // Count by condition
        int Count(Expression<Func<T, bool>> where);

        // Check contains
        bool CheckContains(Expression<Func<T, bool>> predicate);
    }
}
