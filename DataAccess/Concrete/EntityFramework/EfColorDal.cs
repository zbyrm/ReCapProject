﻿using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfColorDal : IColorDal
    {
        public void Add(Color entity)
        {
            using (ReCapProjectDbContext context = new ReCapProjectDbContext() )
            {
                var addedEntity = context.Entry(entity);
                addedEntity.State = EntityState.Added;
                context.SaveChanges();
            }
        }

        public void Delete(Color entity)
        {
            using (ReCapProjectDbContext contex = new ReCapProjectDbContext() )
            {
                var deletedEntity = contex.Entry(entity);
                deletedEntity.State = EntityState.Deleted;
                contex.SaveChanges();
            }
        }

        public List<Color> GetAll(Expression<Func<Color, bool>> filter = null)
        {
            using (ReCapProjectDbContext context = new ReCapProjectDbContext() )
            {
                return filter == null
                    ? context.Set<Color>().ToList()
                    : context.Set<Color>().Where(filter).ToList() ;
            }
        }

        public Color GetById(Expression<Func<Color, bool>> filter)
        {
            using (ReCapProjectDbContext context = new ReCapProjectDbContext())
            {
                return context.Set<Color>().SingleOrDefault(filter);
            }
        }

        public void Update(Color entity)
        {
            using (ReCapProjectDbContext context = new ReCapProjectDbContext() )
            {
                var updatedEntity = context.Entry(entity);
                updatedEntity.State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}