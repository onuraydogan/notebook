using Microsoft.EntityFrameworkCore;
using notebook.core.definitions;
using notebook.core.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;


namespace notebook.core.data
{
    public class IRepositoryBase<TEntity, TContext> : IRepository<TEntity>
       where TEntity : class, IEntity, new()
       where TContext : DbContext, new()
    {

        public TEntity Get(long id, params Expression<Func<TEntity, object>>[] includes)
        {
            using (var context = new TContext())
            {
                IQueryable<TEntity> set = context.Set<TEntity>();
                foreach (var includeProperty in includes)
                {
                    set = set.Include(includeProperty);
                }
                return set.FirstOrDefault(p => p.ID == id);
            }
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter = null, params Expression<Func<TEntity, object>>[] includes)
        {
            using (var context = new TContext())
            {
                IQueryable<TEntity> set = context.Set<TEntity>();
                foreach (var includeProperty in includes)
                {
                    set = set.Include(includeProperty);
                }
                return set.Where(p => p.DataStatus != DataStatus.Deleted).Where(filter).FirstOrDefault();
            }
        }

        public List<TEntity> GetList(Expression<Func<TEntity, bool>> filter = null, params Expression<Func<TEntity, object>>[] includes)
        {
            using (var context = new TContext())
            {
                IQueryable<TEntity> set = context.Set<TEntity>();
                foreach (var includeProperty in includes)
                {
                    set = set.Include(includeProperty);
                }

                return filter == null
                    ? set.Where(p => p.DataStatus != DataStatus.Deleted).ToList()
                    : set.Where(p => p.DataStatus != DataStatus.Deleted).Where(filter).ToList();
            }
        }


        public int Count(Expression<Func<TEntity, bool>> filter = null)
        {
            using (var context = new TContext())
            {
                IQueryable<TEntity> set = context.Set<TEntity>();

                return filter == null
                    ? set.Where(p => p.DataStatus != DataStatus.Deleted).Count()
                    : set.Where(p => p.DataStatus != DataStatus.Deleted).Where(filter).Count();
            }
        }

        public int Sum(Expression<Func<TEntity, int>> column, Expression<Func<TEntity, bool>> filter = null)
        {
            using (var context = new TContext())
            {
                IQueryable<TEntity> set = context.Set<TEntity>();

                return filter == null
                    ? set.Where(p => p.DataStatus != DataStatus.Deleted).Sum(column)
                    : set.Where(p => p.DataStatus != DataStatus.Deleted).Where(filter).Sum(column);
            }
        }
        public long Sum(Expression<Func<TEntity, long>> column, Expression<Func<TEntity, bool>> filter = null)
        {
            using (var context = new TContext())
            {
                IQueryable<TEntity> set = context.Set<TEntity>();

                return filter == null
                    ? set.Where(p => p.DataStatus != DataStatus.Deleted).Sum(column)
                    : set.Where(p => p.DataStatus != DataStatus.Deleted).Where(filter).Sum(column);
            }
        }
        public decimal Sum(Expression<Func<TEntity, decimal>> column, Expression<Func<TEntity, bool>> filter = null)
        {
            using (var context = new TContext())
            {
                IQueryable<TEntity> set = context.Set<TEntity>();

                return filter == null
                    ? set.Where(p => p.DataStatus != DataStatus.Deleted).Sum(column)
                    : set.Where(p => p.DataStatus != DataStatus.Deleted).Where(filter).Sum(column);
            }
        }

        public double Sum(Expression<Func<TEntity, double>> column, Expression<Func<TEntity, bool>> filter = null)
        {
            using (var context = new TContext())
            {
                IQueryable<TEntity> set = context.Set<TEntity>();

                return filter == null
                    ? set.Where(p => p.DataStatus != DataStatus.Deleted).Sum(column)
                    : set.Where(p => p.DataStatus != DataStatus.Deleted).Where(filter).Sum(column);
            }
        }


        public void Add(TEntity entity)
        {
            using (var context = new TContext())
            {
                var addedEntity = context.Entry(entity);
                addedEntity.State = EntityState.Added;
                entity.CreateDate = DateTime.Now;
                entity.DataStatus = DataStatus.Active;
                context.SaveChanges();
            }
        }

        public void Update(TEntity entity)
        {
            using (var context = new TContext())
            {
                var updatedEntity = context.Entry(entity);
                updatedEntity.State = EntityState.Modified;
                entity.UpdateDate = DateTime.Now;
                context.SaveChanges();
            }
        }

        public void Delete(TEntity entity)
        {
            using (var context = new TContext())
            {
                entity.DataStatus = DataStatus.Deleted;
                var updatedEntity = context.Entry(entity);
                updatedEntity.State = EntityState.Modified;
                entity.UpdateDate = DateTime.Now;
                context.SaveChanges();
            }
        }

        public void HardDelete(TEntity entity)
        {
            using (var context = new TContext())
            {
                var updatedEntity = context.Entry(entity);
                updatedEntity.State = EntityState.Deleted;
                context.Remove(entity);
                context.SaveChanges();
            }
        }

        private Expression<Func<TEntity, bool>> GenerateFilter(string propertyName, string value)
        {
            ParameterExpression param = Expression.Parameter(typeof(TEntity), "t");
            MemberExpression member = Expression.Property(param, propertyName);
            MethodInfo filterMethod = null;
            ConstantExpression constant;

            if (member.Type == typeof(short))
            {
                constant = Expression.Constant(Convert.ToInt16(value));
                filterMethod = typeof(short).GetMethods().Where(p => p.Name == "Equals").ToList()[1];
            }
            else if (member.Type == typeof(int))
            {
                constant = Expression.Constant(Convert.ToInt32(value));
                filterMethod = typeof(int).GetMethods().Where(p => p.Name == "Equals").ToList()[1];
            }
            else if (member.Type == typeof(long))
            {
                constant = Expression.Constant(Convert.ToInt64(value));
                filterMethod = typeof(long).GetMethods().Where(p => p.Name == "Equals").ToList()[1];
            }
            else if (member.Type == typeof(bool))
            {
                constant = Expression.Constant(Convert.ToBoolean(value));
                filterMethod = typeof(bool).GetMethods().Where(p => p.Name == "Equals").ToList()[1];
            }
            else if (member.Type == typeof(string))
            {
                constant = Expression.Constant(value, typeof(string));
                filterMethod = typeof(string).GetMethods().Where(p => p.Name == "Contains").FirstOrDefault();
            }
            else
            {
                return null;
            }

            Expression exp = Expression.Call(member, filterMethod, constant);

            return Expression.Lambda<Func<TEntity, bool>>(exp, param);
        }
    }

}
