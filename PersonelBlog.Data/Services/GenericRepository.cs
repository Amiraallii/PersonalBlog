using Microsoft.EntityFrameworkCore;
using PersonalBlog.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalBlog.Data.Services
{
    public class GenericRepository<T> where T : class
    {
        private PersonalBlogContext db;
        private DbSet<T> dbset;
        public GenericRepository(PersonalBlogContext _db)
        {
            db = _db;
            dbset = db.Set<T>();
        }

        public void Add(T entity)
        {
            dbset.Add(entity);
            db.SaveChanges();
        }

        public void Update(T entity)
        {
            dbset.Attach(entity);
            db.Entry(entity).State = EntityState.Modified;
        }

        public void Delete(T entity)
        {
            if (db.Entry(entity).State == EntityState.Detached)
            {
                dbset.Attach(entity);
            }
            dbset.Remove(entity);
        }
    }
}
