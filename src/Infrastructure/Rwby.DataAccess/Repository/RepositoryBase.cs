using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rwby.DataAccess
{
   
    public class RepositoryBase : IDisposable, IRepository
    {
      
        protected DbContext DbContext;


        /// <summary>
        /// Insert new item into database
        /// </summary>
        /// <typeparam name="TItem">Type of item to insert</typeparam>
        /// <param name="item">Item to insert</param>
        /// <param name="saveImmediately">If set to true, saved occurs right away</param>
        /// <returns>Inserted item</returns>
        public TItem Insert<TItem>(TItem item, bool saveImmediately = true)
            where TItem : class
        {
            var set = DbContext.Set<TItem>();

            set.Add(item);
            if (saveImmediately)
            {
                DbContext.SaveChanges();
            }
            return item;
        }

        /// <summary>
        /// Update an item
        /// </summary>
        /// <typeparam name="TItem">Type of item to update</typeparam>
        /// <param name="item">Item to update</param>
        /// <param name="saveImmediately">If set to true, saved occurs right away</param>
        /// <returns>Updated item</returns>
        public TItem Update<TItem>(TItem item, bool saveImmediately = true)
            where TItem : class
        {
            var set = DbContext.Set<TItem>();
            var entry = DbContext.Entry(item);
            if (entry != null && entry.State != EntityState.Detached)
            {
                // entity is already in memory
                entry.State = EntityState.Modified;
            }
            else
            {
                set.Attach(item);
                DbContext.Entry(item).State = EntityState.Modified;
            }



            if (saveImmediately)
            {
                DbContext.SaveChanges();
            }
            return item;
        }

        /// <summary>
        /// Delete an item
        /// </summary>
        /// <typeparam name="TItem">Type of item to delete</typeparam>
        /// <param name="saveImmediately">If set to true, saved occurs right away</param>
        /// <param name="item">Item to delete</param>
        public void Delete<TItem>(TItem item, bool saveImmediately = true)
           where TItem : class
        {
            var set = DbContext.Set<TItem>();
            var entry = DbContext.Entry(item);
            if (entry != null && entry.State != EntityState.Detached)
            {
                // entity is already in memory
                entry.State = EntityState.Deleted;
            }
            else
            {
                set.Attach(item);
                DbContext.Entry(item).State = EntityState.Deleted;
            }

            if (saveImmediately)
            {
                DbContext.SaveChanges();
            }
        }

        /// <summary>
        /// Save all pending changes
        /// </summary>
        public void Save()
        {
            DbContext.SaveChanges();
        }

        /// <summary>
        /// Dispose context
        /// </summary>
        public void Dispose()
        {
            if (DbContext != null)
            {
                DbContext.Dispose();
            }
        }
    }
}
