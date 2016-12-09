using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RealStoriesExposed.Data;
using RealStoriesExposed.Data.Repositories;

namespace RealStoriesExposed.Services
{
    public class BaseService<T> where T: class 
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

    }
}
