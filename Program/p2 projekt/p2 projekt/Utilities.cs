﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Reflection;

namespace p2_projekt
{

    public static class Utilities
    {
        public static DALController LobopDB { get; set; }

        static Utilities()
        {
            LobopDB = new DALController(new Database());
        }

        public class Database : IDAL
        {

            private LobopContext _context;

            public Database()
            {
                _context = new LobopContext();
            }
            

            public void Action<TInput>(Action<LobopContext, DbSet<TInput>> action) where TInput : class
            {
                var db = _context;

                DbSet<TInput> dbSet = VerifyTable<TInput>(db);
                if (dbSet == null) throw new KeyNotFoundException("table ikke fundet");
                action(db, dbSet);
            }

            public int Max<TInput>(Func<TInput,int> pred) where TInput : class
            {
                int result = 0;
                Action<TInput>((db, dbSet) =>
                {
                    if(dbSet.Count() != 0)
                    result = dbSet.Max(pred);
                });

                return result;
            }

            public void Create<TInput>(TInput item) where TInput : class
            {
                Action<TInput>((db, dbSet) =>
                {
                    dbSet.Add(item);
                    db.SaveChanges();
                });

            }

            public void Delete<TInput>(TInput item) where TInput : class
            {

                Action<TInput>((db, dbSet) =>
                {
                    dbSet.Remove(item);
                    db.SaveChanges();
                });

            }

            public void Update<TInput>(TInput item) where TInput : class
            {

                Action<TInput>((db, dbSet) =>
                {
                    dbSet.Attach(item);
                    var entry = db.Entry(item);
                    entry.State = EntityState.Modified;
                    db.SaveChanges();
                });

            }



            private DbSet<T> VerifyTable<T>(LobopContext context) where T : class
            {
                Type lobobContextType = typeof(LobopContext);
                PropertyInfo[] properties = lobobContextType.GetProperties();
                Type DBsetType = typeof(DbSet<T>);

                foreach (PropertyInfo item in properties)
                {
                    if (DBsetType == item.PropertyType)
                    {
                        // table found
                        string dbSetTarget = item.ToString().Split(' ')[1];
                        DbSet<T> dbSet = (DbSet<T>)lobobContextType.GetProperty(dbSetTarget).GetValue(context, null);
                        return dbSet;
                    }
                }
                // table of type not found
                return null;
            }

            public TResult Read<TResult>(Func<TResult, bool> predicate) where TResult : class
            {
                TResult result = null;
                
                Action<TResult>((db, dbSet) =>
                {
                    //_list<string> get = GetAllProperties<TResult>(db);
                    //dbSet.Include("BoatSpaces");
                    //result = dbSet.Include("Boat").FirstOrDefault(predicate);

                    result = dbSet.FirstOrDefault(predicate);
                    
                });

                return result;
            }

            private List<string> GetAllProperties<TEntity>(LobopContext context) where TEntity : class
            {
                Type entityType = typeof(LobopContext);
                PropertyInfo[] properties = entityType.GetProperties();
                string sourceType = typeof(TEntity).ToString().Split('.')[2] + "s";

                List<string> propertiesString = new List<string>();

                foreach (var i in properties)
                {

                    string dbSetTarget = i.ToString().Split(' ', '.', '`')[3];
                    if(dbSetTarget == "DbSet")
                    {
                        
                        if(sourceType != i.Name)
                        {
                            propertiesString.Add(i.Name);
                        }
                    }
                        //TEntity type = (TEntity) TEntityType.GetProperty(dbSetTarget).GetValue(context, null);


                        VerifyTable <TEntity> (context);
                    
                }

                return propertiesString;
            }

            //public IQueryable<TEntity> GetAllIncluding<TEntity>(params Expression<Func<TEntity, object>>[] includeProperties)
            //{
            //    IQueryable<TEntity> queryable = GetAll();
            //    foreach (Expression<Func<TEntity, object>> includeProperty in includeProperties)
            //    {
            //        queryable = queryable.Include<TEntity, object>(includeProperty);
            //    }

            //    return queryable;
            //}


            public IEnumerable<TResult> ReadAll<TResult>(Func<TResult, bool> predicate) where TResult : class
            {
                
                IEnumerable<TResult> result = null;
                Action<TResult>((db, dbSet) =>
                {
                    List<string> get = GetAllProperties<TResult>(db);
                    foreach(string i in get)
                    {
                        dbSet.Include(i);
                    }
                    result = dbSet.Where(predicate).ToList();
                });

                return result;
            }  
        }
    }
}
