using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealStoriesExposed.Services.Contracts
{
    public interface IService<T>
    {
        IQueryable<T> GetAll();

        T Find(object id);

        void Add(T entity);

        void Update(T entity);

        void Delete(object id);

        void SaveChanges();
    }
}
