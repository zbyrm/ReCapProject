using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Core.DataAccess.EntityFramework
{
    public class EfEntityRepositoryBase<TEntity, TContext> : IEntityRepository<TEntity>
         where TEntity : class, IEntity, new()
         where TContext : DbContext, new()
    {
        public void Add(TEntity entity)
        {
            //IDisposable pattern implementation of c#
            using (TContext context = new TContext())
            {
                var addedEntity = context.Entry(entity);//referansı yakalama
                addedEntity.State = EntityState.Added;//eklenecek nesne
                context.SaveChanges();//kaydet
            }
        }

        public void Delete(TEntity entity)
        {
            //IDisposable pattern implementation of c#
            using (TContext context = new TContext())
            {
                var detetedEntity = context.Entry(entity);//referansı yakalama
                detetedEntity.State = EntityState.Deleted;//silme nesne
                context.SaveChanges();//kaydet
            }
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            using (TContext context = new TContext())
            {
                return context.Set<TEntity>().SingleOrDefault(filter);
            }
        }

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            using (TContext context = new TContext())
            {
                return filter == null
                    ? context.Set<TEntity>().ToList()
                    : context.Set<TEntity>().Where(filter).ToList();
            }
        }

        //public TEntity Get(Expression<Func<TEntity, bool>> filter)
        //{
        //    using (TContext context = new TContext())
        //    {
        //        return context.Set<TEntity>().SingleOrDefault(filter);
        //    }
        //}

        public TEntity GetById(Expression<Func<TEntity, bool>> filter)
        {
            using (TContext context = new TContext())
            {
                return context.Set<TEntity>().SingleOrDefault(filter);
            }
        }

        public void Update(TEntity entity)
        {
            //IDisposable pattern implementation of c#
            using (TContext context = new TContext())
            {
                var updatedEntity = context.Entry(entity);//referansı yakalama
                updatedEntity.State = EntityState.Modified;//guncelleme nesne
                context.SaveChanges();//kaydet
            }
        }
    }
}
