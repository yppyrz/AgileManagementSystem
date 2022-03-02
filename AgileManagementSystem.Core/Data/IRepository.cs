using AgileManagementSystem.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgileManagementSystem.Core.Data
{
    /// <summary>
    /// Abstract Class olan Entity'den kalıtım alan class için Repository uygulanabilir.
    /// </summary>
    public interface IRepository<TEntity> where TEntity:Entity
    {
        void Add(TEntity entity);
        void Remove(string Id);
        void Update(TEntity entity);
        void Save();

        TEntity Find(string Id);

        /// <summary>
        /// Linq Query
        /// </summary>
        /// <returns></returns>
        IQueryable<TEntity> GetQuery();

        /// <summary>
        /// Sql Query
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        IQueryable GetSqlRawQuery(string query);


    }
}
