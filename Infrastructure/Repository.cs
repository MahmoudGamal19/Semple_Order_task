
using Doman;
using Doman.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class Repository<T> : IRepository<T> where T : EntitiyBase
    {
        private readonly ApplicationDbContext _db;
        private readonly DbSet<T> entites;
    
        
        public Repository(ApplicationDbContext db)
        {
            this._db = db;
            entites = db.Set<T>();
        }
        public void Delete(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("Null Set");
            }
            entites.Remove(entity);
            _db.SaveChanges();
        }

        public T Get(string Id)
        {
            if (Id == null)
            {
                throw new ArgumentNullException("Null Set");
            }
            return entites.SingleOrDefault(t => t.Id == Id);
        }

        public IEnumerable<T> GetAll()
        {
            return entites.AsEnumerable();
        }

        public void GetByEmail(string Email)
        {
            throw new NotImplementedException();
        }

        public void Insert(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("Null Set");
            }
            entites.Add(entity);
            _db.SaveChanges();
        }

        public void Register(User user)
        {
            throw new NotImplementedException();
        }

        public void Remove(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("Null Set");
            }

            entites.Remove(entity);
            _db.SaveChanges();
        }

        public void SaveChange()
        {
            _db.SaveChanges();
        }

        public void Update(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("Null Set");
            }
            var refrance=entites.FirstOrDefault(t => t.Id == entity.Id);
            _db.Remove(refrance);
            _db.SaveChanges();
            entites.Add(entity);
            _db.SaveChanges();
        }

    }
}
