using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RealStoriesExposed.Models;

namespace RealStoriesExposed.Services.Contracts
{
    public interface IStoryService
    {
        IQueryable<Story> GetAll();
        Story Find(object id);
        void Add(Story story);
        void SaveChanges();
        void Update(Story story);
        void Delete(Story story);
    }
}
