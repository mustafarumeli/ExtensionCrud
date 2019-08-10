using ExtensionCrud.DbObject;
using Microsoft.EntityFrameworkCore;
using System;

namespace ExtensionCrud
{

    public static class ExtensionCrud
    {

        /// <summary>
        /// Inserts DbTable in given database
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="self"></param>
        /// <param name="dbContext"></param>
        /// <returns>DbTable for Fluent Api purposes</returns>
        public static T AddTo<T>(this T self, DbContext dbContext) where T : DbTable
        {
            dbContext.Entry(self).State = EntityState.Added;
            dbContext.SaveChanges();
            return self;
        }
        /// <summary>
        /// Removes DbTable in given database
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="self"></param>
        /// <param name="dbContext"></param>
        /// <returns>DbTable for Fluent Api Purposes</returns>
        public static T RemoveFrom<T>(this T self, DbContext dbContext) where T : DbTable
        {
            dbContext.Entry(self).State = EntityState.Deleted;
            dbContext.SaveChanges();
            return self;
        }
        /// <summary>
        /// Updates DbTable in given database
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="self"></param>
        /// <param name="dbContext"></param>
        /// <returns>DbTable for Fluent Api</returns>
        public static T UpdateInstanceIn<T>(this T self, DbContext dbContext) where T : DbTable
        {
            dbContext.Entry(self).State = EntityState.Modified;
            dbContext.SaveChanges();
            return self;
        }

        }
    }
