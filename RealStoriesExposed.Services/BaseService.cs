using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RealStoriesExposed.Data;
using RealStoriesExposed.Data.Repositories;
using RealStoriesExposed.Services.Contracts;

namespace RealStoriesExposed.Services
{
    public class BaseService<T> : IService<T> where T: class
    {  
        private IRepository<T> repository;
        public BaseService(IRSEData data)
        {
            Data = data;
            repository = Data.GetRepository<T>();
        }

        protected IRSEData Data { get; private set; }

        public IQueryable<T> GetAll()
        {
            return repository.All();
        }

        public T Find(object id)
        {
            return repository.Find(id);
        }

        public virtual void Add(T entity)
        {
            repository.Add(entity);
            repository.SaveChanges();
        }

        public virtual void Update(T entity)
        {
            repository.Update(entity);
        }

        public virtual void Delete(object id)
        {
            repository.Delete(id);
            repository.SaveChanges();
        }

        public void SaveChanges()
        {
            repository.SaveChanges();
        }
    }
}
